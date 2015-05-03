using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CZBK.HeiMaOA.WebApplication.Startup))]
namespace CZBK.HeiMaOA.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
