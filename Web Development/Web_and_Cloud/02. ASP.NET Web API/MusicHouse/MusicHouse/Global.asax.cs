using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MusicHouse.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MusicHouse
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new CreateDatabaseIfNotExists<MusicHouseContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicHouseContext,
                MusicHouse.Context.Migrations.Configuration>());

            // this line ignores infinite loop
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            
            // this allows to view JSON in browser
            var config = GlobalConfiguration.Configuration;
            var jsonformatter = config.Formatters.
                Where(t => t.GetType() == typeof(JsonMediaTypeFormatter)).FirstOrDefault();
            config.Formatters.Remove(jsonformatter);
            config.Formatters.Insert(0, jsonformatter);
            config.Formatters[0].SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}