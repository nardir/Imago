using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axerrio.Images.AOL;
using System.Drawing.Imaging;

namespace Axerrio.Images.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestImage();
        }

        public static void TestImage()
        {
            var filePath = @"C:\Users\Nardi\Documents\Visual Studio 2013\Projects\Imago\Images\649_3.jpg";
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (Image image = Image.FromStream(fileStream))
                {
                    var image200200 = image.Resize(200,200);

                    using (var resizedFile = new FileStream(@"C:\Users\Nardi\Documents\Visual Studio 2013\Projects\Imago\ResizedImages\649_3_200x200.jpg", FileMode.CreateNew))
                    {
                        image200200.Save(resizedFile, ImageFormat.Jpeg);
                    }
                }
            }
        }
    }
}
