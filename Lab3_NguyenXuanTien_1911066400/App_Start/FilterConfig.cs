using System.Web;
using System.Web.Mvc;

namespace Lab3_NguyenXuanTien_1911066400
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
