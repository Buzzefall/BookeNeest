using Microsoft.Owin;
using NLog;
using NLog.Config;
using NLog.Fluent;
using NLog.Targets;
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
