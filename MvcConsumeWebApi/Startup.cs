using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcConsumeWebApi.Startup))]
namespace MvcConsumeWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
