using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object
{
    public class GUI
    {

        public void Windows_Example()
        {
            Mat WindowImage = new Mat("./Resource.jpg", ImreadModes.AnyColor);
            var openCloseWindow = new Window("OpenCVWindow", WindowMode.AutoSize, WindowImage);
            Debug.WriteLine(Cv2.WaitKey());
        }
        public void MouseCallBack_Example()
        {
            using Mat WindowImage = new Mat("./Resource.jpg", ImreadModes.AnyColor);
            using Window foo = new Window("OpenCVWindow", WindowMode.AutoSize, WindowImage);
            Cv2.SetMouseCallback(foo.Name, CallbackOpenCVAnnotate);
            Cv2.WaitKey();
        }
        private void CallbackOpenCVAnnotate(MouseEvent e, int x, int y, MouseEvent flags, IntPtr userdata)
        {
            if (e == MouseEvent.LButtonDown)
            {
                Debug.WriteLine(x + "," + y + " Down");
            }
            else if (flags == MouseEvent.FlagLButton)
            {
                Debug.WriteLine(x + "," + y + " flags");
            }
            else if (e == MouseEvent.LButtonUp)
            {
                Debug.WriteLine(x + "," + y + " Up");
            }
            else if (e == MouseEvent.MouseWheel)
            {
                Debug.WriteLine(x + "," + y + " Wheel");
            }
        }

        public void TrackBar_Example()
        {
            using var src = new Mat(@"./Resource.jpg", ImreadModes.AnyDepth | ImreadModes.AnyColor);
            using var dst = new Mat();

            src.CopyTo(dst);

            var elementShape = MorphShapes.Rect;
            var maxIterations = 10;

            var openCloseWindow = new Window("Open/Close", image: dst);
            var openCloseTrackbar = openCloseWindow.CreateTrackbar(
                name: "Iterations", value: 10, max: maxIterations * 2 + 1,
                callback: (pos, obj) =>
                {
                    var n = pos - maxIterations;
                    var an = n > 0 ? n : -n;
                    var element = Cv2.GetStructuringElement(
                            elementShape,
                            new Size(an * 2 + 1, an * 2 + 1),
                            new Point(an, an));

                    if (n < 0)
                    {
                        Cv2.MorphologyEx(src, dst, MorphTypes.Open, element);
                    }
                    else
                    {
                        Cv2.MorphologyEx(src, dst, MorphTypes.Close, element);
                    }

                    Cv2.PutText(dst, (n < 0) ?
                        string.Format("Open/Erosion followed by Dilation[{0}]", elementShape)
                        : string.Format("Close/Dilation followed by Erosion[{0}]", elementShape),
                        new Point(10, 15), HersheyFonts.HersheyPlain, 1, Scalar.Black);
                    openCloseWindow.Image = dst;
                });


            var erodeDilateWindow = new Window("Erode/Dilate", image: dst);
            var erodeDilateTrackbar = erodeDilateWindow.CreateTrackbar(
                name: "Iterations", value: 10, max: maxIterations * 2 + 1,
                callback: (pos, obj) =>
                {
                    var n = pos - maxIterations;
                    var an = n > 0 ? n : -n;
                    var element = Cv2.GetStructuringElement(
                            elementShape,
                            new Size(an * 2 + 1, an * 2 + 1),
                            new Point(an, an));
                    if (n < 0)
                    {
                        Cv2.Erode(src, dst, element);
                    }
                    else
                    {
                        Cv2.Dilate(src, dst, element);
                    }

                    Cv2.PutText(dst, (n < 0) ?
                        string.Format("Erode[{0}]", elementShape) :
                        string.Format("Dilate[{0}]", elementShape),
                        new Point(10, 15), HersheyFonts.HersheyPlain, 1, Scalar.Black);
                    erodeDilateWindow.Image = dst;
                });


            for (; ; )
            {
                var key = Cv2.WaitKey();

                if ((char)key == 27) // ESC
                    break;

                switch ((char)key)
                {
                    case 'e':
                        elementShape = MorphShapes.Ellipse;
                        break;
                    case 'r':
                        elementShape = MorphShapes.Rect;
                        break;
                    case 'c':
                        elementShape = MorphShapes.Cross;
                        break;
                }
            }

            openCloseWindow.Dispose();
            erodeDilateWindow.Dispose();
        }
    }
}
