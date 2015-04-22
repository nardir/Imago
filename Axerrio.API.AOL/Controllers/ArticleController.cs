using Axerrio.API.AOL.Models;
using Axerrio.Data.AOL;
using Axerrio.Data.AOL.Model;
using Axerrio.Data.AOL.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Axerrio.Images.AOL;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Drawing.Imaging;
using Microsoft.WindowsAzure.Storage.Queue;
using Axerrio.Data.AOL.Model.DTO;
using Newtonsoft.Json;
using System.Web;

namespace Axerrio.API.AOL.Controllers
{
    [RoutePrefix("api/v1/articles")]
    public class ArticleController : ApiController
    {
        [Route("{code}")]
        [HttpGet]
        public async Task<Article> GetArticle(string code)
        {
            using (IArticleRepository articleRepo = new ArticleRepository())
            {
                var article = await articleRepo.GetArticleByCodeAsync(code);

                if (article == null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No article with code = {0}", code)),
                        ReasonPhrase = "Article Not Found"
                    };

                    throw new HttpResponseException(response);
                }

                return article;
            }
        }

        [Route("images")]
        [HttpPost]
        //public async Task<IHttpActionResult> CreateImage()
        public async Task<IEnumerable<PictureInfo>> CreateImage()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();

            provider = await Request.Content.ReadAsMultipartAsync();

            var pictures = new List<PictureInfo>();

            using (IArticleRepository articleRepo = new ArticleRepository())
            {
                foreach (HttpContent content in provider.Contents)
                {
                    Stream stream = await content.ReadAsStreamAsync();
                    Image imageLarge = Image.FromStream(stream);

                    Picture picture = await articleRepo.AddPictureAsync();

                    //Resize and store in blov storage
                    var testName = content.Headers.ContentDisposition.Name;

                     //Retrieve storage account from connection string.
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                        CloudConfigurationManager.GetSetting("StorageConnectionString"));

                     //Create the blob client.
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                     //Retrieve a reference to a container. 
                    CloudBlobContainer imagesContainer = blobClient.GetContainerReference("images");

                     //Create the container if it doesn't already exist.
                    imagesContainer.CreateIfNotExists();

                    imagesContainer.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });

                    CloudBlockBlob imageBlob = imagesContainer.GetBlockBlobReference(string.Format("L{0}.jpg", picture.PictureKey));
                    using (var imageStream = new MemoryStream())
                    {

                        imageLarge.Save(imageStream, ImageFormat.Jpeg);
                        imageStream.Position = 0;

                        imageBlob.Properties.ContentType = "image/jpeg";
                        await imageBlob.UploadFromStreamAsync(imageStream);

                        var pictureInfo = new PictureInfo() { PictureKey = picture.PictureKey, UriLarge = imageBlob.Uri.ToString() };

                        pictures.Add(pictureInfo);

                        picture.UrlLarge = pictureInfo.UriLarge;
                    }

                    await articleRepo.UpdatePictureAsync(picture);

                     //Create the queue client.
                    CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

                     //Retrieve a reference to a queue.
                    CloudQueue queue = queueClient.GetQueueReference("images2process");

                     //Create the queue if it doesn't already exist.
                    queue.CreateIfNotExists();

                    var pictureProcessMessage = new PictureProcessMessage() { PictureKey = picture.PictureKey };
                    //var pictureProcessMessageJson = await JsonConvert.SerializeObjectAsync(pictureProcessMessage);
                    var pictureProcessMessageJson = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(pictureProcessMessage));

                     //send message to queue
                    var message = new CloudQueueMessage(pictureProcessMessageJson);
                    await queue.AddMessageAsync(message);
                }
            }

            return pictures;
        }

        //[Route("imagestest")]
        //[HttpPost]
        ////public async Task<IEnumerable<PictureInfo>> CreateImage([FromBody] byte[] image)
        //public async Task<IEnumerable<PictureInfo>> CreateImage(HttpPostedFileBase image)
        //{
        //    var pictures = new List<PictureInfo>();

        //    //var imageStream = new MemoryStream(image);
        //    //var imageLarge = Image.FromStream(imageStream);
        //    var imageLarge = Image.FromStream(image.InputStream);

        //    // Retrieve storage account from connection string.
        //    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
        //        CloudConfigurationManager.GetSetting("StorageConnectionString"));

        //    // Create the blob client.
        //    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

        //    // Retrieve a reference to a container. 
        //    CloudBlobContainer imagesContainer = blobClient.GetContainerReference("images");

        //    // Create the container if it doesn't already exist.
        //    imagesContainer.CreateIfNotExists();

        //    imagesContainer.SetPermissions(new BlobContainerPermissions
        //    {
        //        PublicAccess = BlobContainerPublicAccessType.Blob
        //    });

        //    CloudBlockBlob imageBlob = imagesContainer.GetBlockBlobReference(string.Format("test.jpg"));
        //    using (var imageStreamTest = new MemoryStream())
        //    {

        //        imageLarge.Save(imageStreamTest, ImageFormat.Jpeg);
        //        imageStreamTest.Position = 0;

        //        imageBlob.Properties.ContentType = "image/jpeg";
        //        await imageBlob.UploadFromStreamAsync(imageStreamTest);
        //    }

        //    return pictures;
        //}
    }
}
