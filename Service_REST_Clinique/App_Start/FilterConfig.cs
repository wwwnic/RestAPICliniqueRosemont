using System.Web;
using System.Web.Mvc;

namespace Service_REST_Clinique
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
