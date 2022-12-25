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
              defaults: new { controller = "Buyer", action = "BuyerDisplayAllProduct", id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "AllProduct",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Buyer", action = "BuyerDisplayAllProduct", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "CreateWallet",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Buyer", action = "CreateWallet", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "AddToCart",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Buyer", action = "AddToCart", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "ViewCart",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Buyer", action = "ViewCart", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "UpdateProfile",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Buyer", action = "UpdateProfile", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "FinalPage",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Buyer", action = "FinalPage", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "DisplayAllProducts",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Seller", action = "DisplayAllProducts", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Delete",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Seller", action = "DeleteProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Add",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Seller", action = "AddProduct", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Update",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Seller", action = "UpdateProducts", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Register",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Login", action = "Register", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Login",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Logout",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Login", action = "Logout", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "SendMail",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Buyer", action = "SendMail", id = UrlParameter.Optional }
           );

        }
    }
}
