﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null, "",
                defaults: new { controller = "Product", action = "List", category = (string) null, page = 1 }
            );

            routes.MapRoute(
                name: "Paging",
                url: "page{page}",
                defaults: new { controller = "Product", action = "List", category = (string) null, page = @"\d+" }
            );

            routes.MapRoute(null, "{category}",
                new { controller = "Product", action = "List", page = 1 }
            );

            routes.MapRoute(null, "{category}/page{page}",
                new { controller = "Product", action = "List", page = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
