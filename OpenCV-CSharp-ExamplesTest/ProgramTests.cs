using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracking_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_Object.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            string[] cmdline = { "1" };
            Program program = new Program();
            Program.Main(cmdline);
            Assert.IsNotNull(program);
        }
    }
}