using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KPITEA.Startup))]
namespace KPITEA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
