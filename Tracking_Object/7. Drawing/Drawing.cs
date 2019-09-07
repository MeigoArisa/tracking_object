using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object
{
    class Drawing
    {
        public void Drawing_method()
        {
            Mat OriginalImage = new Mat("../../opencv.png", ImreadModes.AnyColor);

            Cv2.Line(OriginalImage, new Point(10,10),new Point(630,10), Scalar.Blue);
            Cv2.Circle(OriginalImage,new Point(100,100),40, Scalar.Blue);
            Cv2.Rectangle(OriginalImage,new Rect(20,20,40,40),Scalar.Red);
            Cv2.Ellipse(OriginalImage,new RotatedRect(new Point2f(120,120),new Size2f(200,100),10),Scalar.Yellow);
            Cv2.PutText(OriginalImage,"OpenCVSharp",new Point(600,600),HersheyFonts.Italic,5,Scalar.Black);

            Cv2.ImShow("draw", OriginalImage);
            Cv2.WaitKey();
        }
    }
}
