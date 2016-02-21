using AutoMapper;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

namespace Palla.Labs.Vdt.App.Infraestrutura.AutoMapper
{
    public static class ConfiguraAutoMapper
    {
        public static MapperConfiguration Configurar()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GrupoDto, Grupo>().ReverseMap();
            });

            return config;
        }
    }
}