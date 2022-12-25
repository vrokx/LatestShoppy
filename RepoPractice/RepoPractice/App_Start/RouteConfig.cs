using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RepoPractice
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "DisplayAllProducts", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Delete",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "DeleteProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Add",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "AddProduct", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Update",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "UpdateProducts", id = UrlParameter.Optional }
            );
        }
    }
}
