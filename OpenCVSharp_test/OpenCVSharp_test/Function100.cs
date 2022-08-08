using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Drawing;

namespace Classes {
    public class Function100 {
        
        public static Bitmap RGB2BGR(Bitmap src) {
            FastBitmap im = new FastBitmap(src);
            for(int j = 0; j < im.Width; j++) {
                for(int i = 0; i < im.Height; i++) {
                    Color c = im.GetPixel(i, j);
                    im.SetPixel(i, j, Color.FromArgb(c.B, c.G, c.R));
                }
            }
            return im.ToBitmap();
        }
        
        
        
        /// <summary>
        /// 02グレースケール Grayscale
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Bitmap GrayScale(Bitmap src) {
            FastBitmap original = new FastBitmap(src);
            for (int j = 0; j < original.Width; j++) {
                for (int i = 0; i < original.Height; i++) {
                    Color c = original.GetPixel(i, j);
                    int grayPixel = (int)((double)c.R * 0.2126 + (double)c.G * 0.7152 + (double)c.B * 0.0722);
                    original.SetPixel(i, j, Color.FromArgb(grayPixel, grayPixel, grayPixel));
                }
            }
            return original.ToBitmap();
        }

        /// <summary>
        /// 二値化, Binarization
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Bitmap Binarization(Bitmap src,int th) {
            FastBitmap im = new FastBitmap(src);
            for (int j = 0; j < im.Width; j++) {
                for (int i = 0; i < im.Height; i++) {
                    Color c = im.GetPixel(i, j);
                    if (c.R < th)
                        im.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    else
                        im.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            }
            return im.ToBitmap();
        }

        /// <summary>
        /// 大津の二値化, Otsu's binarization
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Bitmap BinarizationByOtsu(Bitmap src) {
            FastBitmap im = new FastBitmap(src);
            int[] hist = new int[256];
            for (int j = 0; j < im.Width; j++) {
                for (int i = 0; i < im.Height; i++) {
                    Color c = im.GetPixel(i, j);
                    hist[c.R]++;
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

                for (int j = 0; j < i; j++) {
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
                    th = i;
                }
            }

            return Binarization(im.ToBitmap(), th);
        }


        /// <summary>
        /// 減色, color subtraction
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Bitmap ColorSubtraction(Bitmap src) {
            FastBitmap im = new FastBitmap(src);
            for (int j = 0; j < im.Width; j++) {
                for (int i = 0; i < im.Height; i++) {
                    Color c = im.GetPixel(i, j);
                    im.SetPixel(i, j, Color.FromArgb(GetSub(c.R), GetSub(c.G), GetSub(c.B)));
                }
            }
            return im.ToBitmap();
        }

        private static byte GetSub(byte p) {
            if (p < 64)
                return 32;
            else if (p < 128)
                return 96;
            else if (p < 192)
                return 160;
            else
                return 224;
        }

        /// <summary>
        /// 平均プーリング, average pooling
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Bitmap AveragePooling(Bitmap src, Size size) {
            FastBitmap im = new FastBitmap(src);
            for (int j = 0; j < im.Height; j+=size.Height) {
                for (int i = 0; i < im.Width; i+=size.Width) {
                    int h, w;
                    h = size.Height + j;
                    w = size.Width + i;
                    if (h > im.Height)
                        h = im.Height;
                    if(w > im.Width)
                        w = im.Width;

                    int rSum = 0, gSum = 0, bSum = 0, count = 0; ;
                    for(int y = j;y < h; y++) {
                        for(int x = i;x < w; x++) {
                            Color c = im.GetPixel(x, y);
                            rSum += c.R;
                            gSum += c.G;
                            bSum += c.B;
                            count++;
                        }
                    }

                    rSum /= count;
                    gSum /= count;
                    bSum /= count;

                    for (int y = j; y < h; y++) {
                        for (int x = i; x < w; x++) {
                            im.SetPixel(x, y, Color.FromArgb(rSum, gSum, bSum));
                        }
                    }

                }
            }
            return im.ToBitmap();
        }

        /// <summary>
        /// 最大プーリング, max pooling
        /// </summary>
        /// <param name="src"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Bitmap MaxPooling(Bitmap src, Size size) {
            FastBitmap im = new FastBitmap(src);
            for (int j = 0; j < im.Height; j += size.Height) {
                for (int i = 0; i < im.Width; i += size.Width) {
                    int h, w;
                    h = size.Height + j;
                    w = size.Width + i;
                    if (h > im.Height)
                        h = im.Height;
                    if (w > im.Width)
                        w = im.Width;

                    int rMax = 0, gMax = 0, bMax = 0;
                    for (int y = j; y < h; y++) {
                        for (int x = i; x < w; x++) {
                            Color c = im.GetPixel(x, y);
                            if (rMax < c.R) rMax = c.R;
                            if (gMax < c.G) gMax = c.G;
                            if (bMax < c.B) bMax = c.B;
                        }
                    }

                    for (int y = j; y < h; y++) {
                        for (int x = i; x < w; x++) {
                            im.SetPixel(x, y, Color.FromArgb(rMax, gMax, bMax));
                        }
                    }

                }
            }
            return im.ToBitmap();
        }

    }



}
