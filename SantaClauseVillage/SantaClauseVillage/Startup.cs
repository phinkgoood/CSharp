using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SantaClauseVillage.Startup))]
namespace SantaClauseVillage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
