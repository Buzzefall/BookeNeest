using System.Web.Mvc;

namespace BookeNeest.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Admin_Manage",
                url: "Admin/Manage/{action}/{id}",
                defaults: new {area = "Admin", controller = "Manage", action = "Index", id = UrlParameter.Optional},
                namespaces: new [] {"BookeNeest.Web.Areas.Admin.Controllers"}
            );


            context.MapRoute(
                name: "Admin_Books",
                url: "Admin/Books",
                defaults: new {controller = "Book", action = "Recents", id = UrlParameter.Optional},
                namespaces: new [] {"BookeNeest.Web.Controllers"}
            );

            context.MapRoute(
                name: "Admin_Books_Manage",
                url: "Admin/Books/{action}/{id}",
                defaults: new {controller = "Book", id = UrlParameter.Optional},
                namespaces: new [] {"BookeNeest.Web.Areas.Admin.Controllers"}
            );

            context.MapRoute(
                name: "Admin_User",
                url: "Admin/User/{action}/{id}",
                defaults: new {controller = "User", action = "Index", id = UrlParameter.Optional},
                namespaces: new [] {"BookeNeest.Web.Areas.Admin.Controllers"}
            );
            
            context.MapRoute(
                name: "Admin_Default",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new {area = "Admin", controller = "Home", action = "Index", id = UrlParameter.Optional},
                namespaces: new [] {"BookeNeest.Web.Areas.Admin.Controllers", "BookeNeest.Web.Controllers"}
            );
        }
    }
}