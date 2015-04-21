using Axerrio.Data.AOL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axerrio.Data.AOL.Context;
using System.Data.Entity;

namespace Axerrio.Data.AOL.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            using (var context = new AOLContext())
            {
                var articleRepo = context.EntityRepository<Article>();

                return await articleRepo.Query().Where(a => a.Deleted == false).Take(100).ToListAsync();
            }
        }

        public async Task<Article> GetArticleByCode(string code)
        {
            using (var context = new AOLContext())
            {
                var articleRepo = context.EntityRepository<Article>();

                return await articleRepo.Query().Where(a => a.Deleted == false && a.Code == code).FirstOrDefaultAsync();
            }
        }

        public void Dispose()
        {
        }
    }
}
