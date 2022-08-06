using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Classes;



// 02グレースケール Grayscale
string fileName = "Color/Lenna.bmp";
Bitmap src = new Bitmap(fileName);
Bitmap myGray = Function100.GrayScale(src);

Mat img = BitmapConverter.ToMat(src);
Mat cvGray = new Mat(img.Width, img.Height, MatType.CV_8UC1);
Cv2.CvtColor(img, cvGray, ColorConversionCodes.BGR2GRAY);

while (true) {
    Cv2.ImShow("src", img);
    Cv2.ImShow("CvGray", cvGray);
    Cv2.ImShow("MyGray", BitmapConverter.ToMat(myGray));
    Cv2.WaitKey(0);
}