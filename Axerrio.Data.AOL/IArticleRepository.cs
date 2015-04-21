using Axerrio.Data.AOL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axerrio.Data.AOL
{
    public interface IArticleRepository : IDisposable
    {
        Task<IEnumerable<Article>> GetArticlesAsync(); 
    }
}
