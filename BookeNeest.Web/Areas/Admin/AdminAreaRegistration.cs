using System.Web.Mvc;

namespace BookeNeest.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Admin_Books",
                url: "Admin/Books/{action}/{id}",
                defaults: new {controller = "Books", action = "Recents", id = UrlParameter.Optional},
                namespaces: new [] {"BookeNeest.Web.Areas.Admin.Controllers"}
            );
            
            context.MapRoute(
                name: "Admin_Default",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                namespaces: new [] {"BookeNeest.Web.Areas.Admin.Controllers", "BookeNeest.Web.Controllers"}
            );
        }
    }
}