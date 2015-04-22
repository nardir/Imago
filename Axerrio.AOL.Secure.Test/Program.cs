using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Axerrio.AOL.Secure.Test
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Articles articles = new Articles();
            articles.CallArticle();

        }

        
    }
}
