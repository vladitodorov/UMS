using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UMS.APP.Startup))]
namespace UMS.APP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
