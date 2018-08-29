using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookeNeest.Web.Startup))]
namespace BookeNeest.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
