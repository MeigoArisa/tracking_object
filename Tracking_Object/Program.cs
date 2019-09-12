using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object
{
    class Program
    {
        static void Main(string[] args)
        {
            var Command = (args.Length < 1) ? "" : args[0];
            
            switch (Command)
            {
                case "1":
                    break;
                case "1-1":
                    GUI gUI = new GUI();
                    gUI.Windows_Example();
                    gUI.TrackBar_Example();
                    gUI.MouseCallBack_Example();
                    break;
                case "2":
                    Camera camera = new Camera();
                    camera.CaptureCamera();
                    break;
                case "3":
                    Edit_image edit_Image = new Edit_image();
                    break;
                case "4":
                    GrayScale grayScale = new GrayScale();
                    grayScale.GrayScale_example();
                    break;
                case "5":
                    Binarization binarization = new Binarization();
                    binarization.Binarization_exammple();
                    break;
                case "6":
                    merge merge = new merge();
                    merge.Merge_method();
                    break;
                case "7":
                    Drawing drawing = new Drawing();
                    drawing.Drawing_method();
                    break;
                case "8":
                    Geometric_trans geometric_Trans = new Geometric_trans();
                    geometric_Trans.Geometric();
                    break;
                case "9":
                    BackgroundSubtractor backgroundSubtractor = new BackgroundSubtractor();
                    backgroundSubtractor.BackgroundSubtractor_Example();
                    break;
                case "10":
                    Blur blur = new Blur();
                    blur.Blur_Example();
                    break;
                case "11":
                    Morphology_operation morphology_Operation = new Morphology_operation();
                    morphology_Operation.Morphology_example();
                    break;
                case "12":
                    Labeling labeling = new Labeling();
                    labeling.Labeling_example();
                    break;
                case "13":
                    Contour_Corner contour_Corner = new Contour_Corner();
                    contour_Corner.Contour_example();
                    contour_Corner.Corner_example();
                    break;
                case "14":
                    Bounding_rec bounding_Rec = new Bounding_rec();
                    bounding_Rec.BoundingRect_Example();
                    break;
                case "15":
                    ConvexHull convexHull = new ConvexHull();
                    convexHull.ConvexHull_Example();
                    break;
                case "16":
                    Template_matching template_Matching = new Template_matching();
                    template_Matching.Template_matching_example();
                    break;
                default:
                    Console.WriteLine($"아무것도 선택되지 않았습니다.");
                    break;
            }
            Console.WriteLine($"종료");
        }
    }
}
