using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace OpenCVExamples
{
    class GrayScale
    {
        public Mat GrayScale_example()
        {
            using Mat OriginalImage = new Mat();
            using Mat GrayImage = new Mat();
            Cv2.CvtColor(OriginalImage, GrayImage, ColorConversionCodes.RGB2GRAY);
            return GrayImage;
        }
    }
}
