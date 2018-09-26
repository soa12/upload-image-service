using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(laba2.Startup))]
namespace laba2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
