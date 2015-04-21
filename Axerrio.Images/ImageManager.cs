﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Axerrio.Images
{
    public class ImageManager
    {
        public void Resize()
        {
            // Load an image from the calling Assembly's resources only by passing the relative path

            var fileBytes = File.ReadAllBytes(@"V:\Photos\741_3.jpg");
            var stream = new MemoryStream(fileBytes);

            WriteableBitmap writeableBmp = BitmapFactory.New(1, 1).FromStream(stream);
            var resizedImage = writeableBmp.Resize(200, 200, WriteableBitmapExtensions.Interpolation.Bilinear);

            var smallBytes = resizedImage.ToByteArray();

            

            var fs = new BinaryWriter(new FileStream(@"C:\\small.jpg", FileMode.Append, FileAccess.Write));
            fs.Write(smallBytes);
            fs.Close();


        }

        static WriteableBitmap CreateBitmap(byte[] bytes)
        {
            return null;
        }
    }
}
