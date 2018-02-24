using AppWeb.ActionFilters;
using System.Web;
using System.Web.Mvc;

namespace AppWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggerFilter());
        }
    }
}
