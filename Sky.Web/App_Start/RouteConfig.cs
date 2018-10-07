using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Sky.Web.Controllers;

namespace Sky.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            // 注册默认首页，启动魔方站点时能自动跳入后台，同时为Home预留默认过度视图页面
            routes.MapRoute(
                name: "Cube",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { typeof(HomeController).Namespace }
            );
           

            //Error pages aspx后缀 无形装逼,最为致命 2018年10月6日22:03:14
            routes.MapRoute("404", "404.aspx", new { controller = "ErrorPage", action = "Error404" });
            routes.MapRoute("500", "500.aspx", new { controller = "ErrorPage", action = "Error500" });

        }
    }
}
