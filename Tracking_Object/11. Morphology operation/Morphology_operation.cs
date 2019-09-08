using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object
{
    class Morphology_operation
    {
        public void Morphology_example()
        {
            using var src = new Mat(@"./Resource.jpg", ImreadModes.AnyDepth | ImreadModes.AnyColor);
            using var dst = new Mat();

            src.CopyTo(dst);

            var elementShape = MorphShapes.Rect;

            var element = Cv2.GetStructuringElement(elementShape,new Size(5, 5));
            Cv2.MorphologyEx(src, dst, MorphTypes.Open, element);
            using var openCloseWindow = new Window("Open/Close", image: dst);
            Cv2.WaitKey();
        }
    }
}
