using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object
{
    class Binarization
    {
        public Mat Binarization_method()
        {
            using Mat OriginalImage = new Mat("../../opencv.png",ImreadModes.AnyColor);
            using Mat GrayImage = new Mat();
            using Mat thresimg = new Mat();
            Cv2.CvtColor(OriginalImage, GrayImage, ColorConversionCodes.RGB2GRAY);
            Cv2.Threshold(GrayImage, thresimg, 100, 255, ThresholdTypes.Binary);
            Cv2.ImShow("thresimg", thresimg);
            Cv2.WaitKey();
            return GrayImage;
        }
    }
}
