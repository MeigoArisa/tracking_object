using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object
{
    class Template_matching
    {
        public void Template_matching_example()
        {
            RunTemplateMatch("./Resource.png", "./CutResource.png");
        }
        private void RunTemplateMatch(string reference, string template)
        {
            using var refMat = new Mat(reference);
            using var tplMat = new Mat(template);
            using var res = new Mat(refMat.Rows - tplMat.Rows + 1, refMat.Cols - tplMat.Cols + 1, MatType.CV_32FC1);
                  
            using var gref = refMat.CvtColor(ColorConversionCodes.BGR2GRAY);
            using var gtpl = tplMat.CvtColor(ColorConversionCodes.BGR2GRAY);

            Cv2.MatchTemplate(gref, gtpl, res, TemplateMatchModes.CCoeffNormed);
            Cv2.Threshold(res, res, 0.8, 1.0, ThresholdTypes.Tozero);

            while (true)
            {
                double minval, maxval, threshold = 0.8;
                Point minloc, maxloc;
                Cv2.MinMaxLoc(res, out minval, out maxval, out minloc, out maxloc);

                if (maxval >= threshold)
                {
                    //그릴 사각형을 설정
                    Rect r = new Rect(new Point(maxloc.X, maxloc.Y), new Size(tplMat.Width, tplMat.Height));
                    Debug.WriteLine($"{minval.ToString()}, {maxval.ToString()}, {minloc.ToString()}, {maxloc.ToString()}, {r.ToString()}");

                    //일치하는 영역의 사각형을 그립니다.
                    Cv2.Rectangle(refMat, r, Scalar.LimeGreen, 2);

                    //MinMaxLoc에서 다시 같은 영역을 찾을 수 없도록 채웁니다.
                    Rect outRect;
                    Cv2.FloodFill(res, maxloc, new Scalar(0), out outRect, new Scalar(0.1), new Scalar(1.0), FloodFillFlags.Link8);
                }
                else
                    break;
            }
            Cv2.ImShow("Matches", refMat);
            Cv2.WaitKey();
        }
    }
}
