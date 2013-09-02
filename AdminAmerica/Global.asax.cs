using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AdminAmerica
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            // add Sub Directory View Engine
            ViewEngines.Engines.Add(new SubDirViewEngine()); 
        }
    }

    public class SubDirViewEngine : RazorViewEngine
    {
        // add sub directory to "shared" to organize Infinity Trust partial views
        private static string[] NewITViewFormats = new[] { 
        "~/Views/{1}/InfinityTrust/{0}.cshtml",
        "~/Views/Shared/InfinityTrust/{0}.cshtml"
    };

        public SubDirViewEngine()
        {
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(NewITViewFormats).ToArray();
        }

    }
}