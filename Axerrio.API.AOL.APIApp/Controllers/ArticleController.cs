using Axerrio.API.AOL.APIApp.Models;
using Axerrio.Data.AOL;
using Axerrio.Data.AOL.Model;
using Axerrio.Data.AOL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Axerrio.API.AOL.APIApp.Controllers
{
    [RoutePrefix("api/v1/articles")]
    public class ArticleController : ApiController
    {
        //[Route("echo/{id:int}")]
        //[HttpGet]
        //public string Echo(int id)
        //{
        //    if (id == 0)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }

        //    return string.Format("echo {0}", id);
        //}

        //[Route("articles")]
        //[HttpGet]
        //public async Task<IEnumerable<Article>> GetArticles()
        ////public List<Article> GetArticles()
        //{
        //    try
        //    {
        //        IEnumerable<Article> articles = null;

        //        using (IArticleRepository articleRepo = new ArticleRepository())
        //        {
        //            //return await articleRepo.GetArticlesAsync();
        //            articles = await articleRepo.GetArticlesAsync();
        //            //articles = articleRepo.GetArticlesAsync().Result;
        //        }

        //        return articles;
        //    }
        //    catch (Exception ex)
        //    {
        //        var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
        //        {
        //            Content = new StringContent(ex.ToString())
        //        };

        //        throw new HttpResponseException(response);
        //    }
        //}

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<ArticleDTO>> GetArticlesDTO()
        {
            //List<ArticleDTO> articles = new List<ArticleDTO>() {new ArticleDTO { ArticleKey = 1, Code = "Code 1"}, new ArticleDTO{ ArticleKey = 2, Code = "Code 2"}};

            try
            {

                using (IArticleRepository articleRepo = new ArticleRepository())
                {
                    var articles = await articleRepo.GetArticlesAsync();

                    //return articles.Select(a => new ArticleDTO() { ArticleKey = a.ArticleKey, Code = a.Code, Description = a.Description });

                    var articlesDTO = articles.Select(a => new ArticleDTO() { ArticleKey = a.ArticleKey, Code = a.Code, Description = a.Description }).ToList();

                    var articleDTO = articlesDTO.First();
                        
                    articleDTO.Pictures.Add(new PictureDTO() { PictureKey = 1, PictureUri = "Picture test 1" });
                    articleDTO.Pictures.Add(new PictureDTO() { PictureKey = 2, PictureUri = "Picture test 2" });
                    articleDTO.Pictures.Add(new PictureDTO() { PictureKey = 3, PictureUri = "Picture test 3" });

                    return articlesDTO;
                }
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.ToString())
                };

                throw new HttpResponseException(response);
            }
        }

        [Route("{code}")]
        [HttpGet]
        public async Task<ArticleDTO> GetArticleDTO(string code)
        {
            try
            {

                using (IArticleRepository articleRepo = new ArticleRepository())
                {
                    var article = await articleRepo.GetArticleByCodeAsync(code);

                    return new ArticleDTO() { ArticleKey = article.ArticleKey, Code = article.Code, Description = article.Description };
                }
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.ToString())
                };

                throw new HttpResponseException(response);
            }
        }
    }
}
