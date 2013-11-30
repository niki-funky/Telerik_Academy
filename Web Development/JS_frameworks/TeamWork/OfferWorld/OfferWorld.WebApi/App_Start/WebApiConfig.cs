using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OfferWorld.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                name: "ItemsApi2",
                routeTemplate: "api/items/{id}/{action}",
                defaults: new
                {
                    controller = "items",
                }
            );

            config.Routes.MapHttpRoute(
                 name: "ItemsApi",
                 routeTemplate: "api/items/{action}",
                 defaults: new
                 {
                     controller = "items",
                 }
             );


            config.Routes.MapHttpRoute(
                 name: "CategoriesApi",
                 routeTemplate: "api/categories/{action}",
                 defaults: new
                 {
                     controller = "categories",
                 }
             );


            config.Routes.MapHttpRoute(
                 name: "UsersApi",
                 routeTemplate: "api/users/{action}",
                 defaults: new
                 {
                     controller = "users",
                 }
             );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
