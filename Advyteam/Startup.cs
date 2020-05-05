using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Advyteam.Startup))]
namespace Advyteam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
