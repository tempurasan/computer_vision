using OpenCvSharp;

var img = new Mat(new OpenCvSharp.Size(256, 256), MatType.CV_8UC3, new Scalar(35, 123, 254));

Cv2.ImShow("Image", img);

Console.ReadLine();