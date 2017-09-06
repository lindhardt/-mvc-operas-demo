using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OperasWebSites
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "testRoute",
                url: "opera/title/{id}",
                defaults: new
                {
                    controller = "Opera",
                    action = "Details"
                   
                },
                constraints: new { id = "[0-9]+"}
                );

            routes.MapRoute(
                name: "OperaByTitleRoute",
                url: "opera/title/{title}",
                defaults: new
                {
                    controller = "Opera",
                    action = "DetailsByTitle"
                });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
