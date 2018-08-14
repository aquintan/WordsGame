using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WordsGame.Web.Startup))]
namespace WordsGame.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
