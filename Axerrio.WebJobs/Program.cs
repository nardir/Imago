using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Axerrio.Data.AOL.Model.DTO;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Blob;
using Axerrio.Images.AOL;

namespace Axerrio.WebJobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            JobHost host = new JobHost();
            host.RunAndBlock();
        }

        public static void ProcessQueueMessage(
            [QueueTrigger("images2process")] PictureProcessMessage processMessage,
            [Blob("images/L{PictureKey}.jpg", FileAccess.Read)] Stream input,
            [Blob("images/M{PictureKey}.jpg")] CloudBlockBlob mediumOutputBlob,
            [Blob("images/S{PictureKey}.jpg")] CloudBlockBlob smallOutputBlob
            )
        {
            int pictureKeyToProcess = processMessage.PictureKey;

            var largeImage = Image.FromStream(input);
            var smallImage = largeImage.Resize(200, 200);
            var mediumImage = largeImage.Resize(1024, 1024);

            using (var smallMemoryStream = smallOutputBlob.OpenWrite())
            {
                smallOutputBlob.Properties.ContentType = "image/jpeg";
                smallImage.Save(smallMemoryStream,ImageFormat.Jpeg);
                //smallMemoryStream.Position = 0;
                //smallOutputBlob.UploadFromStreamAsync(smallMemoryStream, smallMemoryStream.Length);
            }

            using (var mediumMemoryStream = mediumOutputBlob.OpenWrite())
            {
                mediumOutputBlob.Properties.ContentType = "image/jpeg";
                mediumImage.Save(mediumMemoryStream, ImageFormat.Jpeg);
              //  mediumMemoryStream.Position = 0;
              //  mediumOutputBlob.UploadFromStreamAsync(mediumMemoryStream, mediumMemoryStream.Length);
            }

        }
        
    }
}
