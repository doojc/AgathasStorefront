using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agathas.Storefront.UI.Web.MVC.Startup))]
namespace Agathas.Storefront.UI.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
