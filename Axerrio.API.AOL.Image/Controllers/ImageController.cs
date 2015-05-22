using Axerrio.API.AOL.Image.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Axerrio.API.AOL.Image.Controllers
{
    [RoutePrefix("api/v1/images")]
    public class ImageController : ApiController
    {
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetImages()
        {
            return Ok();
        }

        [Route("{Id}", Name="GetImageById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetImage(int Id)
        {
            var imageInfo = new ImageInfo() { Name = Id.ToString() };

            return Ok(imageInfo);
        }

        //[Route()]
        //[HttpPost]
        //public async Task<IHttpActionResult> PostImage([FromBody] ImageInfo imageInfo)
        //{
        //    return Created(Url.Link("GetImageById", new { id = 100 }), imageInfo);
        //}

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateImage()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            //MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
            //provider = await Request.Content.ReadAsMultipartAsync();
            var provider = await Request.Content.ReadAsMultipartAsync<MultipartFormDataMemoryStreamProvider>(new MultipartFormDataMemoryStreamProvider());

            NameValueCollection formData = provider.FormData;
            //var value = formData[0];
            var files = provider.Files;

            foreach (HttpContent content in provider.Contents)
            {
                Stream stream = await content.ReadAsStreamAsync();
                //Image imageLarge = Image.FromStream(stream);
            }



            return Ok();
        }
    }
}
