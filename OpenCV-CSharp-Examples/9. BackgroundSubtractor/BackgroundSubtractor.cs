using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVExamples
{
    class BackgroundSubtractor
    {
        public void BackgroundSubtractor_Example()
        {
            VideoCapture capture = new VideoCapture(0);

            using var MOG2 = BackgroundSubtractorMOG2.Create();
            using var MOG = BackgroundSubtractorMOG.Create();
            using var GMG = BackgroundSubtractorGMG.Create();
            using var KNN = BackgroundSubtractorKNN.Create();

            using Mat frame = new Mat();
            using Mat MOG2remove = new Mat();
            using Mat MOGremove = new Mat();
            using Mat GMG2remove = new Mat();
            using Mat KNNremove = new Mat();
            Window win_MOG2 = new Window("MOG2");
            Window win_GMG = new Window("GMG");
            Window win_MOG = new Window("MOG");
            Window win_KNN = new Window("KNN");

            while (Cv2.WaitKey(1) < 0)
            {
                capture.Read(frame);
                MOG2.Apply(frame, MOG2remove);
                MOG.Apply(frame, MOGremove);
                GMG.Apply(frame, GMG2remove);
                KNN.Apply(frame, KNNremove);

                win_MOG2.ShowImage(MOG2remove);
                win_GMG.ShowImage(MOGremove);
                win_MOG.ShowImage(GMG2remove);
                win_KNN.ShowImage(KNNremove);
            }
        }
    }
}
