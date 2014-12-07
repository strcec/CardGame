using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CardGame_iStone.Startup))]
namespace CardGame_iStone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
