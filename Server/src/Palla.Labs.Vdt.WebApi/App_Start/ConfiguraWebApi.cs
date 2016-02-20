using System.Web.Http;
using Palla.Labs.Vdt.App.Infraestrutura.AutoMapper;
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
            ConfiguraMongo.Configurar();
            var mapperConfiguration = ConfiguraAutoMapper.Configurar();
            ConfiguraIoC.Configurar(config, mapperConfiguration);
        }
    }
}
