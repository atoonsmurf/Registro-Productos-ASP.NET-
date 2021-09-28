using System.Web;
using System.Web.Mvc;

namespace DSW1_EL1_SebastianSandoval
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
