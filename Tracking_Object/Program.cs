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
            Template_matching template = new Template_matching();
            template.Template_matching_example();
        }
    }
}
