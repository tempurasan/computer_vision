// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
Bitmap test = new Bitmap("Color/Lenna.bmp");
FastBitmap fast = new FastBitmap(test);


public class FastBitmap {
    private Bitmap src;
    private BitmapData srcBirmapData;
    private byte[] srcpixels;


    public FastBitmap(Bitmap src) {
        this.src = src;
        srcBirmapData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.WriteOnly, src.PixelFormat);
        srcpixels = new byte[srcBirmapData.Stride * src.Height];
        Marshal.Copy(srcBirmapData.Scan0, srcpixels, 0, srcpixels.Length);
        src.UnlockBits(srcBirmapData);
        
        ToGrayScale();
    }

    
    public void ToGrayScale() {
        byte[] graypixels = new byte[srcBirmapData.Stride * src.Height];
        
        for (int j = 0; j < src.Height; j++) {
            for(int i = 0; i < src.Width; i++) {
                int position = i * 3 + srcBirmapData.Stride * j;
                int ave = (srcpixels[position + 0] + srcpixels[position + 1] + srcpixels[position + 2]) / 3;
                graypixels[position + 0] = (byte)ave;
                graypixels[position + 1] = (byte)ave;
                graypixels[position + 2] = (byte)ave;
            }
        }
        GetBitmap(src, graypixels, src.Width, src.Height).Save("bray.bmp");
    }

    public Bitmap GetBitmap(Bitmap src,byte[] pixels, int width, int height) {
        Bitmap dst = (Bitmap)src.Clone();
        BitmapData dstData;
        dstData = dst.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, dst.PixelFormat);
        Marshal.Copy(pixels, 0, dstData.Scan0, pixels.Length);
        dst.UnlockBits(dstData);
        return dst;
    }

}