using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new AxerrioAPIAOLAPIApp();

                //var articles = client.Article.GetArticlesDTO();

                var article = client.Article.GetArticleDTO("A0036541");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
