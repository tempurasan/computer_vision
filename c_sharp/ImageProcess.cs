using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public void ToGrayScale() {
            byte[] graypixels = new byte[srcBirmapData.Stride * src.Height];

            for (int j = 0; j < src.Height; j++) {
                for (int i = 0; i < src.Width; i++) {
                    Color c = GetPixel(srcpixels, i, j);
                    int ave = (int)(c.R * 0.2126 + c.G * 0.7152 + c.B * 0.0722);
                    SetPixel(graypixels, i, j, Color.FromArgb(ave, ave, ave));
                }
            }
            GetBitmap(src, graypixels, src.Width, src.Height).Save("dst/gray.bmp");
        }

        public void RGB2BGR() {
            byte[] bgr = new byte[srcBirmapData.Stride * src.Height];

            for (int j = 0; j < src.Height; j++) {
                for (int i = 0; i < src.Width; i++) {
                    Color c = GetPixel(srcpixels, i, j);
                    SetPixel(bgr, i, j, Color.FromArgb(c.B, c.G, c.R));
                }
            }
            GetBitmap(src, bgr, src.Width, src.Height).Save("dst/bgr.bmp");
        }

        public void ToBinarization(int th) {
            byte[] binarypixels = new byte[srcBirmapData.Stride * src.Height];

            for (int j = 0; j < src.Height; j++) {
                for (int i = 0; i < src.Width; i++) {
                    Color c = GetPixel(srcpixels, i, j);
                    int ave = (int)(c.R * 0.2126 + c.G * 0.7152 + c.B * 0.0722);
                    if (ave > th)
                        SetPixel(binarypixels, i, j, Color.FromArgb(255, 255, 255));
                    else
                        SetPixel(binarypixels, i, j, Color.FromArgb(0, 0, 0));
                }
            }
            GetBitmap(src, binarypixels, src.Width, src.Height).Save("dst/binary.bmp");

        }

        public void ToBinarizationByOstu() {

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

        private void SetPixel(byte[] pixels, int x, int y, Color c) {
            int position = x * 3 + srcBirmapData.Stride * y;
            pixels[position + 0] = (byte)c.R;
            pixels[position + 1] = (byte)c.G;
            pixels[position + 2] = (byte)c.B;

        }


        public Bitmap GetBitmap(Bitmap src, byte[] pixels, int width, int height) {
            Bitmap dst = (Bitmap)src.Clone();
            BitmapData dstData;
            dstData = dst.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, dst.PixelFormat);
            Marshal.Copy(pixels, 0, dstData.Scan0, pixels.Length);
            dst.UnlockBits(dstData);
            return dst;
        }

    }

}
