using AutoMapper;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

namespace Palla.Labs.Vdt.App.Infraestrutura.AutoMapper
{
    public static class ConfiguraAutoMapper
    {
        public static IMapper Mapeador { get; private set; }

        public static MapperConfiguration Configurar()
        {
            var config = new MapperConfiguration(cfg =>
            {
                ConfiguraGrupo(cfg);
                ConfiguraCliente(cfg);
            });

            Mapeador = config.CreateMapper();
            return config;
        }

        private static void ConfiguraGrupo(IMapperConfiguration cfg)
        {
            cfg.CreateMap<GrupoDto, Grupo>().ReverseMap();
        }

        private static void ConfiguraCliente(IMapperConfiguration cfg)
        {
            cfg.CreateMap<ClienteDto, Cliente>()
                .ConstructUsing(x => new Cliente(
                    x.Id,
                    x.GrupoId.ParaGuid(),
                    new Cnpj(x.Cnpj),
                    x.Nome,
                    x.Codigo,
                    new Endereco(x.Logradouro, x.Numero, x.Complemento, x.Bairro, x.Cidade, x.Estado, x.Cep),
                    new CorreioEletronico(x.CorreioEletronicoLoja),
                    new CorreioEletronico(x.CorreioEletronicoManutencao),
                    new CorreioEletronico(x.CorreioEletronicoAdministracao)))
                .ReverseMap()
                .ConstructUsing(x => new ClienteDto
                {
                    Nome = x.Nome,
                    Cnpj = x.Cnpj.ToString(),
                    Codigo = x.Codigo,
                    GrupoId = x.GrupoId.ToString(),
                    Logradouro = x.Endereco.Logradouro,
                    Numero = x.Endereco.Numero,
                    Complemento = x.Endereco.Complemento,
                    Bairro = x.Endereco.Bairro,
                    Cidade = x.Endereco.Logradouro,
                    Estado = x.Endereco.Estado,
                    Cep = x.Endereco.Cep,
                    CorreioEletronicoLoja = x.CorreioEletronicoLoja.ToString(),
                    CorreioEletronicoManutencao = x.CorreioEletronicoManutencao.ToString(),
                    CorreioEletronicoAdministracao = x.CorreioEletronicoAdministracao.ToString()
                });
        }
    }
}