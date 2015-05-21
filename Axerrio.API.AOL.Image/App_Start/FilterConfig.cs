using System.Web;
using System.Web.Mvc;

namespace Axerrio.API.AOL.Image
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
