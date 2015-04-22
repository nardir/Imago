using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axerrio.Data.AOL;
using Axerrio.Data.AOL.Model.DTO;
using Axerrio.Data.AOL.Repository;
using Axerrio.Images.AOL;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Axerrio.WebJobs
{
    public class PictureQueueFunctions
    {
        public async static Task ProcessQueueMessage(
            [QueueTrigger("images2process")] PictureProcessMessage processMessage,
            [Blob("images/L{PictureKey}.jpg", FileAccess.Read)] Stream input,
            [Blob("images/M{PictureKey}.jpg")] CloudBlockBlob mediumOutputBlob,
            [Blob("images/S{PictureKey}.jpg")] CloudBlockBlob smallOutputBlob
            )
        {
            try
            {
                int pictureKeyToProcess = processMessage.PictureKey;

                Console.WriteLine("ImageKey:  " + pictureKeyToProcess);

                var largeImage = Image.FromStream(input);

                var smallImage = largeImage.Resize(200, 200);
                var mediumImage = largeImage.Resize(1024, 1024);

                using (var smallMemoryStream = smallOutputBlob.OpenWrite())
                {
                    smallOutputBlob.Properties.ContentType = "image/jpeg";
                    smallImage.Save(smallMemoryStream, ImageFormat.Jpeg);
                }

                using (var mediumMemoryStream = mediumOutputBlob.OpenWrite())
                {
                    mediumOutputBlob.Properties.ContentType = "image/jpeg";
                    mediumImage.Save(mediumMemoryStream, ImageFormat.Jpeg);
                }

                using (IArticleRepository articleRepo = new ArticleRepository())
                {
                    var picture = await articleRepo.GetPictureByKeyAsync(pictureKeyToProcess);

                    picture.UrlSmall = smallOutputBlob.Uri.ToString();
                    picture.UrlMedium = mediumOutputBlob.Uri.ToString();

                    await articleRepo.UpdatePictureAsync(picture);
                }

               // throw new Exception("test");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async static void ProcessQueueMessagePoison(
            [QueueTrigger("images2process-poison")] PictureProcessMessage processMessage
            )
        {

            int pictureKeyToProcess = processMessage.PictureKey;

            Console.WriteLine("[Poison] Deze blijft maar mislukken!:  " + pictureKeyToProcess);
        }
    }
}
