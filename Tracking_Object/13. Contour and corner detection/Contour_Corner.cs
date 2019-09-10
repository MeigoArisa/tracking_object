using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object
{
    class Contour_Corner
    { 

        public void Contour_example()
        {
            using var src = new Mat("./TextSample.png");
            Cv2.ImShow("Source", src);

            using var gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGRA2GRAY);

            using var threshImage = new Mat();
            Cv2.Threshold(gray, threshImage, 50, 255, ThresholdTypes.Binary);

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
                Cv2.DrawContours(
                    dst,
                    contours,
                    contourIndex,
                    color: Scalar.Red,
                    thickness: 1,
                    lineType: LineTypes.Link8,
                    hierarchy: hierarchyIndexes,
                    maxLevel: int.MaxValue);
            
                contourIndex = hierarchyIndexes[contourIndex].Next;
            }

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey();
        }

        public void Corner_example()
        {
            using var src = new Mat("./TextSample.png");
            Cv2.ImShow("Source", src);

            using var gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGRA2GRAY);

            using var threshImage = new Mat();
            Cv2.Threshold(gray, threshImage, 50, 255, ThresholdTypes.Binary);

            int cornerCount = 150;
            Point2f[] corners = Cv2.GoodFeaturesToTrack(threshImage, cornerCount, 0.01, 5, null, 3, true, 0.01);

            using var dst = new Mat();
            Cv2.CvtColor(threshImage, dst, ColorConversionCodes.GRAY2BGR);

            for (int i = 0; i < cornerCount; i++)
            {
                Cv2.Circle(dst, new Point(corners[i].X, corners[i].Y), 3, Scalar.Red, 2);
            }

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey();
        }
    }
}
