using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Musicly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            // Older way of handling routes
            //routes.MapRoute(
            //    "SongsByReleaseDate",
              //  "songs/released/{year}/{month}",
                //new { controller = "Songs", action = "ByReleaseDate"},
                //new { year = @"\d{4}", month = @"\d{2}"}
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
