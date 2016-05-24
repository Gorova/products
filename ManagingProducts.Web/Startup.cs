using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagingProducts.Web.Startup))]
namespace ManagingProducts.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
