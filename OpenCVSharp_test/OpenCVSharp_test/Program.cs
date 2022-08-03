using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Classes;

string srcFileName = "Color/Lenna.bmp";

Mat img = new Mat(srcFileName);
ImageProcess src = new ImageProcess(new Bitmap(srcFileName));

while (true) {
    Cv2.ImShow("Image", img);
    Cv2.ImShow("Bitmap", BitmapConverter.ToMat(src.GetSrcBitmap()));
    Cv2.WaitKey(0);
}