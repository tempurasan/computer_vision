using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Classes;


//001チャネル入れ替え
//string fileName = "Color/Lenna.bmp";
//Bitmap src = new Bitmap(fileName);
//Bitmap myDst = Function100.RGB2BGR(src);

//Mat cvSrc = BitmapConverter.ToMat(src);
//Mat cvDst = new Mat(cvSrc.Width, cvSrc.Height, MatType.CV_8UC3);
//Cv2.CvtColor(cvSrc, cvDst, ColorConversionCodes.BGR2RGB);

//while (true) {
//    Cv2.ImShow("src", cvSrc);
//    Cv2.ImShow("CvGray", cvDst);
//    Cv2.ImShow("MyGray", BitmapConverter.ToMat(myDst));
//    Cv2.WaitKey(0);
//}



// 002グレースケール Grayscale
//string fileName = "Color/Lenna.bmp";
//Bitmap src = new Bitmap(fileName);
//Bitmap myGray = Function100.GrayScale(src);

//Mat img = BitmapConverter.ToMat(src);
//Mat cvGray = new Mat(img.Width, img.Height, MatType.CV_8UC1);
//Cv2.CvtColor(img, cvGray, ColorConversionCodes.BGR2GRAY);

//while (true) {
//    Cv2.ImShow("src", img);
//    Cv2.ImShow("CvGray", cvGray);
//    Cv2.ImShow("MyGray", BitmapConverter.ToMat(myGray));
//    Cv2.WaitKey(0);
//}

//003 二値化, Binarization
//string fileName = "Color/Lenna.bmp";
//Bitmap src = new Bitmap(fileName);
//Bitmap myGray = Function100.GrayScale(src);
//Bitmap myDst = Function100.Binarization(myGray, 128);

//Mat cvSrc = BitmapConverter.ToMat(src);
//Mat cvGray = new Mat(cvSrc.Width, cvSrc.Height, MatType.CV_8UC1);
//Mat cvDst = new Mat(cvSrc.Width, cvSrc.Height, MatType.CV_8UC1);
//Cv2.CvtColor(cvSrc, cvGray, ColorConversionCodes.BGR2GRAY);
//Cv2.Threshold(cvGray, cvDst, 128, 255, ThresholdTypes.Binary);


//while (true) {
//    Cv2.ImShow("src", cvSrc);
//    Cv2.ImShow("CvGray", cvDst);
//    Cv2.ImShow("MyGray", BitmapConverter.ToMat(myDst));
//    Cv2.WaitKey(0);
//}


////004大津の二値化, Otsu's binarization
//string fileName = "Color/Lenna.bmp";
//Bitmap src = new Bitmap(fileName);
//Bitmap myGray = Function100.GrayScale(src);
//Bitmap myDst = Function100.BinarizationByOtsu(myGray);

//Mat cvSrc = BitmapConverter.ToMat(src);
//Mat cvGray = new Mat(cvSrc.Width, cvSrc.Height, MatType.CV_8UC1);
//Mat cvDst = new Mat(cvSrc.Width, cvSrc.Height, MatType.CV_8UC1);
//Cv2.CvtColor(cvSrc, cvGray, ColorConversionCodes.BGR2GRAY);
//Cv2.Threshold(cvGray, cvDst, 0, 255, ThresholdTypes.Otsu);

//while (true) {
//    Cv2.ImShow("src", cvSrc);
//    Cv2.ImShow("CvDst", cvDst);
//    Cv2.ImShow("MyDst", BitmapConverter.ToMat(myDst));
//    Cv2.WaitKey(0);
//}


////005hsv変換まだ
//string fileName = "Color/Lenna.bmp";
//Bitmap src = new Bitmap(fileName);
//Bitmap myDst = Function100.RGB2BGR(src);

//Mat cvSrc = BitmapConverter.ToMat(src);
//Mat cvDst = new Mat(cvSrc.Width, cvSrc.Height, MatType.CV_8UC3);
//Cv2.CvtColor(cvSrc, cvDst, ColorConversionCodes.BGR2RGB);

//while (true) {
//    Cv2.ImShow("src", cvSrc);
//    Cv2.ImShow("CvGray", cvDst);
//    Cv2.ImShow("MyGray", BitmapConverter.ToMat(myDst));
//    Cv2.WaitKey(0);
//}



////006減色, color subtraction
//string fileName = "Color/Lenna.bmp";
//Bitmap src = new Bitmap(fileName);
//Bitmap myDst = Function100.ColorSubtraction(src);

//Mat cvSrc = BitmapConverter.ToMat(src);

//while (true) {
//    Cv2.ImShow("src", cvSrc);
//    Cv2.ImShow("MyDst", BitmapConverter.ToMat(myDst));
//    Cv2.WaitKey(0);
//}

////007平均プーリング, average pooling
//string fileName = "Color/Lenna.bmp";
//Bitmap src = new Bitmap(fileName);
//Bitmap myDst = Function100.AveragePooling(src, new System.Drawing.Size(5, 5));

//Mat cvSrc = BitmapConverter.ToMat(src);

//while (true) {
//    Cv2.ImShow("src", cvSrc);
//    Cv2.ImShow("MyDst", BitmapConverter.ToMat(myDst));
//    Cv2.WaitKey(0);
//}

//最大プーリング, max pooling

string fileName = "Color/Lenna.bmp";
Bitmap src = new Bitmap(fileName);
Bitmap myDst = Function100.MaxPooling(src, new System.Drawing.Size(5, 5));

Mat cvSrc = BitmapConverter.ToMat(src);

while (true) {
    Cv2.ImShow("src", cvSrc);
    Cv2.ImShow("MyDst", BitmapConverter.ToMat(myDst));
    Cv2.WaitKey(0);
}
////テンプレ
//string fileName = "Color/Lenna.bmp";
//Bitmap src = new Bitmap(fileName);
//Bitmap myDst = Function100.RGB2BGR(src);

//Mat cvSrc = BitmapConverter.ToMat(src);
//Mat cvDst = new Mat(cvSrc.Width, cvSrc.Height, MatType.CV_8UC3);
//Cv2.CvtColor(cvSrc, cvDst, ColorConversionCodes.BGR2RGB);

//while (true) {
//    Cv2.ImShow("src", cvSrc);
//    Cv2.ImShow("CvDst", cvDst);
//    Cv2.ImShow("MyDst", BitmapConverter.ToMat(myDst));
//    Cv2.WaitKey(0);
//}