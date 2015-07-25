using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RequestMaster.Startup))]
namespace RequestMaster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
