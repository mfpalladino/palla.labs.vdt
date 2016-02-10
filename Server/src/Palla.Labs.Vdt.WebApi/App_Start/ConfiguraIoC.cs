using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Palla.Labs.Vdt
{
    public static class ConfiguraIoC
    {
        public static void Configurar(HttpConfiguration config)
        {
            var container = new Container();
            //

            container.RegisterWebApiControllers(config);

            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}