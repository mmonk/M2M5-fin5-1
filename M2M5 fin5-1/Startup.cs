using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(M2M5_fin5_1.Startup))]
namespace M2M5_fin5_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
