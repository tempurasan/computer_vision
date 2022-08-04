using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Classes;

string srcFileName = "Color/Lenna.bmp";

Mat img = new Mat(srcFileName);
Mat gray = new Mat(img.Width, img.Height, MatType.CV_8UC1);
Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);
Mat binary = gray.Threshold(0, 255,ThresholdTypes.Otsu);

ImageProcess src = new ImageProcess(new Bitmap(srcFileName));
while (true) {
    Cv2.ImShow("Image", img);
    Cv2.ImShow("Bitmap", BitmapConverter.ToMat(src.GetSrcBitmap()));
    Cv2.ImShow("Cv Binary ostu", binary);
    Cv2.ImShow("My Binary ostu", BitmapConverter.ToMat(src.ToBinarizationByOstu()));
    Cv2.WaitKey(0);
}