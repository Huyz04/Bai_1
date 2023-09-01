using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Bai1.WebAPI.Models;
using Bai1.WebAPI.Provider;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Bai1.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string requestedPath = Request.Url.AbsolutePath;

            if (string.IsNullOrEmpty(requestedPath) || requestedPath == "/")
            {
                Context.RewritePath("/Page/Bai1.html");
            }
        }
    }
}
