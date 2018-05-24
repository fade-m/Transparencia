using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hckaton2018v2.Startup))]
namespace Hckaton2018v2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
