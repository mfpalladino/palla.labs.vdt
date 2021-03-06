﻿using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.Infraestrutura.Web;
using Palla.Labs.Vdt.Excecoes;

namespace Palla.Labs.Vdt
{
    public static class ConfiguraWebApi
    {
        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ConfiguraJson.Configurar(config);
            ConfiguraPoliticaExcecoes.Configurar(config);
            ConfiguraMongo.Configurar();
            ConfiguraIoC.Configurar(config);

            var provider = new SimpleModelBinderProvider(typeof(EquipamentoDto), new EquipamentoDtoModelBinder());
            config.Services.Insert(typeof(ModelBinderProvider), 0, provider);
        }
    }
}
