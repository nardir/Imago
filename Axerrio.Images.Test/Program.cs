using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axerrio.Images.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestImage();
        }

        public static void TestImage()
        {
            ImageManager im = new ImageManager();
            im.Resize();
        }
    }
}
