using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Musicly.Startup))]

namespace Musicly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}