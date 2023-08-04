﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bai1.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{product_id}",
                defaults: new { product_id = RouteParameter.Optional }
            );
          
        }
    }
}
