using System.Web.Http;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.Excecoes;

namespace Palla.Labs.Vdt
{
    public static class ConfiguraWebApi
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ConfiguraJson.Configurar(config);
            ConfiguraPoliticaExcecoes.Configurar(config);
            ConfiguraIoC.Configurar(config);
            ConfiguraMongo.Configurar();
        }
    }
}
