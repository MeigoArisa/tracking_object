using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object
{
    class Geometric_trans
    {
        Point2f[] srcPoints = new Point2f[] {
            new Point2f(69, 110),
            new Point2f(81, 857),
            new Point2f(1042, 786),
            new Point2f(1038, 147),
        };

        Point2f[] dstPoints = new Point2f[] {
            new Point2f(0, 0),
            new Point2f(0, 480),
            new Point2f(640, 480),
            new Point2f(640, 0),
        };
        public void Geometric()
        {
            //var srcPoints = new Point2f[] {
            //    new Point2f(69, 110),
            //    new Point2f(81, 857),
            //    new Point2f(1042, 786),
            //    new Point2f(1038, 147),
            //};
            //
            //var dstPoints = new Point2f[] {
            //    new Point2f(0, 0),
            //    new Point2f(0, 480),
            //    new Point2f(640, 480),
            //    new Point2f(640, 0),
            //};

            using var matrix = Cv2.GetPerspectiveTransform(srcPoints, dstPoints);
            using var OriginalImage = new Mat("./Resource.jpg", ImreadModes.AnyColor);
            using var dst = new Mat(new Size(640, 480), MatType.CV_8UC3);
            Cv2.WarpPerspective(OriginalImage, dst, matrix, dst.Size());
            using var Window = new Window("result", dst);
            Cv2.WaitKey();
            
        }

        public void MouseCallBack()
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
                
            }
            else if (flags == MouseEvent.FlagLButton)
            {
            }
            else if (e == MouseEvent.LButtonUp)
            {
            }
            else if (e == MouseEvent.MouseWheel)
            {
            }
        }
    }
}
