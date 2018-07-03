using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(USER_MST_UPDATE.Startup))]
namespace USER_MST_UPDATE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
