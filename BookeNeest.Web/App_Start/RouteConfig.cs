using System.Web.Mvc;
using System.Web.Routing;

namespace BookeNeest.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // MapRoute() call order is IMPORTANT
            routes.MapRoute(
                name: "Books",
                url: "Books/{action}/{id}",
                defaults: new { controller = "Books", action = "Recents", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
