using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Palla.Labs.Vdt
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            var log = log4net.LogManager.GetLogger(typeof(WebApiApplication));

            log.Warn("Aplicação iniciada.");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var log = log4net.LogManager.GetLogger(typeof(WebApiApplication));

            var ex = Server.GetLastError();
            log.Error("Uma exceção inesperada ocorreu", ex);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            var log = log4net.LogManager.GetLogger(typeof(WebApiApplication));

            log.Warn("Aplicação finalizada.");
        }
    }
}
