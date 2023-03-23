using System.Web;
using System.Web.Mvc;

namespace Proj_BTL_NguyenMinhQuang_2018600016
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
