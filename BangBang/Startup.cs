using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BangBang.Startup))]
namespace BangBang
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
