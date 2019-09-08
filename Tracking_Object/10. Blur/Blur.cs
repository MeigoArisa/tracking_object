using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object
{
    class Blur
    {
        public void Blur_Example()
        {
            using Mat WindowImage = new Mat("./Resource.jpg", ImreadModes.AnyColor);
            using Mat blurImage = new Mat(WindowImage.Size(), WindowImage.Type());
            Cv2.Blur(WindowImage, blurImage, new Size(5, 5));
            using var openCloseWindow = new Window("OpenCVWindow", WindowMode.AutoSize, WindowImage);
            Debug.WriteLine(Cv2.WaitKey());
        }
    }
}
