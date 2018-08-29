using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookeNest.Web.Startup))]
namespace BookeNest.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
