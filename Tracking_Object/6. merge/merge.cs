using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object
{
    class merge
    {
        public void Merge_method()
        {
            using Mat OriginalImage = new Mat("../../opencv.png", ImreadModes.AnyColor);
            using Mat FillMatrix = Mat.Zeros(OriginalImage.Size(), MatType.CV_8UC1);

            Mat[] rgb;

            Cv2.Split(OriginalImage, out rgb);

            Mat[] r = { FillMatrix, FillMatrix, rgb[2] };
            Mat[] g = { FillMatrix, rgb[1], FillMatrix };
            Mat[] b = { rgb[0], FillMatrix, FillMatrix };

            using Mat merge = new Mat();

            Cv2.Merge(r, merge);
            Cv2.ImShow("r", merge);

            Cv2.Merge(g, merge);
            Cv2.ImShow("g", merge);

            Cv2.Merge(b, merge);
            Cv2.ImShow("b", merge);

            Cv2.Merge(rgb, merge);

            Cv2.ImShow("remerge", merge);
            Cv2.WaitKey();
        }
    }
}
