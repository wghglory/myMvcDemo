using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAPP.Startup))]
namespace MvcAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
