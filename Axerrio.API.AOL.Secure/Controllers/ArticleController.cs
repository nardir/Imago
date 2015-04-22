using Axerrio.Data.AOL;
using Axerrio.Data.AOL.Model;
using Axerrio.Data.AOL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace Axerrio.API.AOL.Secure.Controllers
{
    [RoutePrefix("api/v1/articles")]
    [Authorize]
    public class ArticleController : ApiController
    {
        [Route("{code}")]
        [HttpGet]
        public async Task<Article> GetArticle(string code)
        {
            using (IArticleRepository articleRepo = new ArticleRepository())
            {
                //if (!ClaimsPrincipal.Current.Identity.IsAuthenticated)
                //{
                //    throw new HttpResponseException(HttpStatusCode.Unauthorized);
                //}

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
    }
}
