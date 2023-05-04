using System.Web;
using System.Web.Mvc;

namespace Latihan_LKS_Laundry_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
