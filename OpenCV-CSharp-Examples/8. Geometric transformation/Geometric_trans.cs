﻿using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVExamples
{
    class Geometric_trans
    {
        List<Point2f> point2Fs = new List<Point2f>();

        Point2f[] srcPoints = new Point2f[] {
            new Point2f(0, 0),
            new Point2f(0, 0),
            new Point2f(0, 0),
            new Point2f(0, 0),
        };

        Point2f[] dstPoints = new Point2f[] {
            new Point2f(0, 0),
            new Point2f(0, 480),
            new Point2f(640, 480),
            new Point2f(640, 0),
        };

        Mat OriginalImage;
        public void Geometric()
        {
            OriginalImage = new Mat("./Resource.png", ImreadModes.AnyColor);
            using var Window = new Window("result", OriginalImage);

            Cv2.SetMouseCallback(Window.Name, CallbackOpenCVAnnotate);
            Window.WaitKey();
        }
        private void CallbackOpenCVAnnotate(MouseEvent e, int x, int y, MouseEvent flags, IntPtr userdata)
        {
            if (e == MouseEvent.LButtonDown)
            {
                point2Fs.Add(new Point2f(x, y));
                if(point2Fs.Count == 4)
                {
                    srcPoints = new Point2f[]
                    {
                        point2Fs[0],
                        point2Fs[1],
                        point2Fs[2],
                        point2Fs[3]
                    };
                    using var matrix = Cv2.GetPerspectiveTransform(srcPoints, dstPoints);
                    using var dst = new Mat(new Size(640, 480), MatType.CV_8UC3);
                    Cv2.WarpPerspective(OriginalImage, dst, matrix, dst.Size());
                    using var dsts = new Window("dst", dst);
                    point2Fs.Clear();
                }
            }
        }
    }
}
