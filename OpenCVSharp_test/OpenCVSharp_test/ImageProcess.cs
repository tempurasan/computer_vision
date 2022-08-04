using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Classes {

    public class ImageProcess {
        private Bitmap src;
        private BitmapData srcBirmapData;
        private byte[] srcpixels;


        public ImageProcess(Bitmap src) {
            this.src = src;
            srcBirmapData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.WriteOnly, src.PixelFormat);
            srcpixels = new byte[srcBirmapData.Stride * src.Height];
            Marshal.Copy(srcBirmapData.Scan0, srcpixels, 0, srcpixels.Length);
            src.UnlockBits(srcBirmapData);

        }

        public Bitmap ToGrayScale() {
            byte[] graypixels = new byte[srcBirmapData.Stride * src.Height];

            for (int j = 0; j < src.Height; j++) {
                for (int i = 0; i < src.Width; i++) {
                    Color c = GetPixel(srcpixels, i, j);
                    int ave = (int)(c.R * 0.2126 + c.G * 0.7152 + c.B * 0.0722);
                    SetPixel(graypixels, i, j, Color.FromArgb(ave, ave, ave));
                }
            }
            return GetBitmap(src, graypixels, src.Width, src.Height);
        }

        public Bitmap RGB2BGR() {
            byte[] bgr = new byte[srcBirmapData.Stride * src.Height];

            for (int j = 0; j < src.Height; j++) {
                for (int i = 0; i < src.Width; i++) {
                    Color c = GetPixel(srcpixels, i, j);
                    SetPixel(bgr, i, j, Color.FromArgb(c.B, c.G, c.R));
                }
            }
            return GetBitmap(src, bgr, src.Width, src.Height);
        }

        public Bitmap ToBinarization(int th) {
            byte[] binarypixels = new byte[srcBirmapData.Stride * src.Height];

            for (int j = 0; j < src.Height; j++) {
                for (int i = 0; i < src.Width; i++) {
                    Color c = GetPixel(srcpixels, i, j);
                    double ave = (double)((double)c.R * 0.2126 + (double)c.G * 0.7152 + (double)c.B * 0.0722);
                    if (ave > th)
                        SetPixel(binarypixels, i, j, Color.FromArgb(255, 255, 255));
                    else
                        SetPixel(binarypixels, i, j, Color.FromArgb(0, 0, 0));
                }
            }
            return GetBitmap(src, binarypixels, src.Width, src.Height);
        }

        public Bitmap ToBinarizationByOstu() {
            byte[] graypixels = new byte[srcBirmapData.Stride * src.Height];
            int[] hist = new int[256];

            for (int j = 0; j < src.Height; j++) {
                for (int i = 0; i < src.Width; i++) {
                    Color c = GetPixel(srcpixels, i, j);
                    int ave = (int)((double)c.R * 0.2126 + (double)c.G * 0.7152 + (double)c.B * 0.0722);
                    SetPixel(graypixels, i, j, Color.FromArgb(ave, ave, ave));
                    hist[ave]++;
                }
            }

            int th = 0;
            float max = 0;

            for (int i = 1; i < hist.Length; i++) {
                int sum1 = 0;
                int sum2 = 0;
                int w1 = 0;
                int w2 = 0;

                float ave1, ave2;

                for(int j = 0; j < i; j++) {
                    w1 += hist[j];
                    sum1 += hist[j] * j;
                }
                ave1 = (float)sum1 / (float)w1;

                for (int j = i; j < hist.Length; j++) {
                    w2 += hist[j];
                    sum2 += hist[j] * j;
                }
                ave2 = (float)sum2 / (float)w2;

                float temp = (float)(w1 * w2) * ((ave1 - ave2) * (ave1 - ave2));

                if (temp > max) {
                    max = temp;
                    Console.WriteLine("{0},{1}",temp, i);
                    th = i;
                }
            }
            Console.WriteLine(th);
            return ToBinarization(th);

            //for(int i = 1; i < hist.Length - 1; i++) {
            //    int sum1 = 0, sum2 = 0;
            //    float ave1 = 0, ave2 = 0;
            //    for (int j = 0; j < i ; j++) {
            //        sum1 += hist[j];
            //    }
            //    ave1 = sum1 / (float)i;

            //    for (int j = i; j < hist.Length; j++) {
            //        sum2 += hist[j];
            //    }
            //    ave2 = sum2 / (hist.Length - i);

            //    float temp = sum1 * sum2 * ((ave1 - ave2) * (ave1 - ave2));

            //    if(temp > max) {
            //        max = temp;
            //        th = i;
            //    }
            //}

        }

        //public Bitmap RGB2HSV(byte[] pixels) {
            
        //}

        private class HSV {
            public float Hue;
            public float Saturation;
            public float Value;
            public Color c;

            private void GetHSV() {
                //if(c.R > c.G && c.R > c.B) {
                //    Hue = (c.G - c.R) / 
                //}
                //if (c.G > c.R && c.G > c.B) {

                //}
                //if (c.B > c.R] && c.B > c.G) {

                //}
            }

        }

        private Color GetPixel(byte[] pixels, int x, int y) {
            Color c;
            int position = x * 3 + srcBirmapData.Stride * y;
            byte r = pixels[position + 0];
            byte g = pixels[position + 1];
            byte b = pixels[position + 2];

            c = Color.FromArgb(r, g, b);

            return c;
        }
        public Bitmap GetSrcBitmap() {
            return src;
        }

        private void SetPixel(byte[] pixels, int x, int y, Color c) {
            int position = x * 3 + srcBirmapData.Stride * y;
            pixels[position + 0] = (byte)c.R;
            pixels[position + 1] = (byte)c.G;
            pixels[position + 2] = (byte)c.B;

        }

        private Bitmap GetBitmap(Bitmap src, byte[] pixels, int width, int height) {
            Bitmap dst = (Bitmap)src.Clone();
            BitmapData dstData;
            dstData = dst.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, dst.PixelFormat);
            Marshal.Copy(pixels, 0, dstData.Scan0, pixels.Length);
            dst.UnlockBits(dstData);
            return dst;
        }

    }

}
