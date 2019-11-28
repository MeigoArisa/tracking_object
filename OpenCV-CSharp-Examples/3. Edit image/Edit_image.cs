using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVExamples
{
    class Edit_image
    {
        private unsafe void ForEachAsVec3b(Mat image)
        {
            image.ForEachAsVec3b((ptrValue, ptrPosition) =>
            {
                ptrValue->Item0 = (byte)(255 - ptrValue->Item0);
                ptrValue->Item1 = (byte)(255 - ptrValue->Item1);
                ptrValue->Item2 = (byte)(255 - ptrValue->Item2);
            });
        }
        private void AtVec3b(Mat image)
        {
            for (int i = 0; i < image.Rows; i++)
            {
                for (int j = 0; j < image.Cols; j++)
                {
                    var Matvec3b = image.At<Vec3b>(i, j);

                    Matvec3b.Item0 = (byte)(255 - Matvec3b.Item0);
                    Matvec3b.Item1 = (byte)(255 - Matvec3b.Item1);
                    Matvec3b.Item2 = (byte)(255 - Matvec3b.Item2);

                    image.Set<Vec3b>(i, j, Matvec3b);
                }
            }
        }
    }
}
