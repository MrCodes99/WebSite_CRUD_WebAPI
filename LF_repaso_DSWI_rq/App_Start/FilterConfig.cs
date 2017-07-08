using System.Web;
using System.Web.Mvc;

namespace LF_repaso_DSWI_rq
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
