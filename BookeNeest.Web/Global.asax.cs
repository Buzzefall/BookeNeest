using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace BookeNeest.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private ILogger _logger;
        private ILogger Logger => _logger ?? (LogManager.GetCurrentClassLogger());

        protected void Application_Start()
        {
            // Setup logs 
            ///////////////////////////////////////
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget("FileTarget")
            {
                FileName = "${basedir}/Log/BookeNeest.Web.Log.txt",
                Layout = "${longdate} ${level} ${message}  ${exception}"
            };
            config.AddTarget(fileTarget);

            var consoleTarget = new ColoredConsoleTarget("ConsoleTarget")
            {
                Layout = @"${date:format=HH\:mm\:ss} ${level} ${message} ${exception}"
            };
            config.AddTarget(consoleTarget);

            LogManager.Configuration = config;

            this.Disposed += (sender, args) => Logger.Info("Application Dispose");
            this.Error += (sender, args) => Logger.Info("Application Error");
            // End Setup logs
            ///////////////////////////////////////

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void Init()
        {
            Logger.Info("Application Init");
        }
    }
}