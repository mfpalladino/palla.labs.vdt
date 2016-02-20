using AutoMapper;

namespace Palla.Labs.Vdt.App.Infraestrutura.AutoMapper
{
    public static class ConfiguraAutoMapper
    {
        public static MapperConfiguration Configurar()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ServicosAplicacao.Dtos.Grupo, Dominio.Modelos.Grupo>().ReverseMap();
            });

            return config;
        }
    }
}