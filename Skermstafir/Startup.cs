using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Skermstafir.Startup))]
namespace Skermstafir
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
