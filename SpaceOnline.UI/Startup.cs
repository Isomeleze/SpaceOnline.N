using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpaceOnline.UI.Startup))]
namespace SpaceOnline.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
