using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Attitude.Shared.Extensions;

namespace AttitudeClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.DOMConfigurator.Configure();
        }

        void Application_Error(object sender, EventArgs e)
        {
            try
            {
                var lastError = Server.GetLastError();
                LogHelper.Error(sender, lastError);
            }
            catch (Exception exception)
            {
            }
            
        }
    }
}
