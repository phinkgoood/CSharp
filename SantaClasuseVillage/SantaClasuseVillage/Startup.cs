using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SantaClasuseVillage.Startup))]
namespace SantaClasuseVillage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
