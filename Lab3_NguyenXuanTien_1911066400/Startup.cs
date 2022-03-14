using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab3_NguyenXuanTien_1911066400.Startup))]
namespace Lab3_NguyenXuanTien_1911066400
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
