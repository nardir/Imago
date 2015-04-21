using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axerrio.Data.AOL;
using Axerrio.Data.AOL.Model;
using Axerrio.Data.AOL.Repository;

namespace Axerrio.Data.AOL.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGetArticles();
        }

        static void TestGetArticles()
        {
            try
            {
                using (IArticleRepository repo = new ArticleRepository())
                {
                    var articles = repo.GetArticlesAsync().Result;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
