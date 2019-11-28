using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVExamples
{
    class Bounding_rec
    {
        public void BoundingRect_Example()
        {
            using var src = new Mat("./TextSample.png");
            Cv2.ImShow("Source", src);

            using var gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGRA2GRAY);

            using var threshImage = new Mat();
            Cv2.Threshold(gray, threshImage, 100, 255, ThresholdTypes.Binary);

            Point[][] contours;
            HierarchyIndex[] hierarchyIndexes;
            Cv2.FindContours(
                threshImage,
                out contours,
                out hierarchyIndexes,
                mode: RetrievalModes.CComp,
                method: ContourApproximationModes.ApproxSimple);

            if (contours.Length == 0)
            {
                throw new NotSupportedException("검출된 윤곽선 없음.");
            }

            using var dst = new Mat();
            Cv2.CvtColor(threshImage, dst, ColorConversionCodes.GRAY2BGR);

            var contourIndex = 0;
            while ((contourIndex >= 0))
            {
                var contour = contours[contourIndex];

                var boundingRect = Cv2.BoundingRect(contour);
                Cv2.Rectangle(dst,
                    new Point(boundingRect.X, boundingRect.Y),
                    new Point(boundingRect.X + boundingRect.Width, boundingRect.Y + boundingRect.Height),
                    new Scalar(0, 0, 255),
                    2);
                contourIndex = hierarchyIndexes[contourIndex].Next;
            }

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey();
        }
    }
}
