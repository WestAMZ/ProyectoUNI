using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PAEDUCA.Startup))]
namespace PAEDUCA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
