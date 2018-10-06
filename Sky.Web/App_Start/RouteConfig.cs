using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sky.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //Error pages aspx后缀 无形装逼,最为致命 2018年10月6日22:03:14
            routes.MapRoute("404", "404.aspx", new { controller = "ErrorPage", action = "Error404" });
            routes.MapRoute("500", "500.aspx", new { controller = "ErrorPage", action = "Error500" });

        }
    }
}
