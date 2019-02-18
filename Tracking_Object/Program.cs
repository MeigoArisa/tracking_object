using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (VideoCapture video = new VideoCapture(0))
            using (var MOG2 = BackgroundSubtractorMOG2.Create(300,90))
            using (Mat frame = new Mat())
            using (Mat remove = new Mat())
            using (Mat resizedImage = new Mat())
            using (Window win_MOG2 = new Window("MOG2"))
            {
                VideoCapture capture = new VideoCapture("Test.mp4");
                int sleepTime = (int)Math.Round(1000 / capture.Fps);
                //video.FrameWidth = 640;
                //video.FrameHeight = 480;
                //video.AutoFocus = false;
                //video.XI_AutoWB = 4;
                while (Cv2.WaitKey(1) < 0)
                {
                    Cv2.WaitKey(sleepTime);
                    capture.Read(frame);
                    MOG2.Apply(frame, remove);
                    Point[][] contours;
                    HierarchyIndex[] hierarchyIndexes;
                    var element = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(3,3));
                    Cv2.Blur(remove, remove, new Size(3,3),null,BorderTypes.Replicate);
                    Cv2.MorphologyEx(remove, remove, MorphTypes.Dilate, element);
                    Cv2.Threshold(remove, remove,100,255,ThresholdTypes.Binary);
                    Cv2.ImShow("응기잇2", remove);
                    Cv2.FindContours(
                        remove,
                        out contours,
                        out hierarchyIndexes,
                        mode: RetrievalModes.External,
                        method: ContourApproximationModes.ApproxTC89KCOS);

                    if (contours.Length == 0)
                    {
                        //throw new NotSupportedException("Couldn't find any object in the image.");
                    }
                    else
                    {
                        var contourIndex = 0;
                        while ((contourIndex >= 0))
                        {
                            var contour = contours[contourIndex];
                            var boundingRect = Cv2.BoundingRect(Cv2.ConvexHull(contour,true));

                            if (boundingRect.Width > 10 || boundingRect.Height > 10)
                            {
                                Cv2.Rectangle(frame,
                                    new Point(boundingRect.X, boundingRect.Y),
                                    new Point(boundingRect.X + boundingRect.Width, boundingRect.Y + boundingRect.Height),
                                    new Scalar(0, 0, 255),
                                    1);

                                var roi = new Mat(remove, boundingRect);
                                Cv2.Resize(roi, resizedImage, roi.Size());
                                Cv2.Canny(remove, remove, 100, 255);
                                Cv2.FillConvexPoly(remove, contours[contourIndex], new Scalar(0, 0, 0), LineTypes.Link8);
                                contourIndex = hierarchyIndexes[contourIndex].Next;
                            }
                            else
                            {
                                contourIndex = hierarchyIndexes[contourIndex].Next;
                            }
                        }
                    }
                    var tmp = new Mat();
                    var tmp2 = new Mat();
                    Cv2.ImShow("", resizedImage);
                    Cv2.ImShow("Segmented Source", frame);
                    Cv2.ImShow("Detected", remove);
                    
                }
            }
        }
    }
}
