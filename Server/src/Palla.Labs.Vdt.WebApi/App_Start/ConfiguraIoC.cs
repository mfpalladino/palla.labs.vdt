using System.Web.Http;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Dominio.Servicos;
using Palla.Labs.Vdt.App.Infraestrutura.Json;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.Infraestrutura.PayPal;
using Palla.Labs.Vdt.App.Infraestrutura.Seguranca;
using Palla.Labs.Vdt.App.Infraestrutura.SimpleInjector;
using Palla.Labs.Vdt.App.ServicosAplicacao;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Palla.Labs.Vdt
{
    public static class ConfiguraIoC
    {
        public static void Configurar(HttpConfiguration config)
        {
            var container = new Container();

            var leitorConfiguracoes = new ConfigBancoDadosArquivo();

            container.RegisterSingle<IConfigBancoDados>(leitorConfiguracoes);
            container.RegisterSingle<IMongoClient>(new MongoClient(leitorConfiguracoes.StringConexao));

            container.RegisterSingle<ConversorDeJson, ConversorDeJson>();
            container.RegisterSingle(new BuscadorDeInstancias(container));

            container.RegisterSingle<FabricaGrupo, FabricaGrupo>();
            container.RegisterSingle<FabricaGrupoDto, FabricaGrupoDto>();
            container.RegisterSingle<FabricaUsuario, FabricaUsuario>();
            container.RegisterSingle<FabricaUsuarioDto, FabricaUsuarioDto>();
            container.RegisterSingle<FabricaCliente, FabricaCliente>();
            container.RegisterSingle<FabricaClienteDto, FabricaClienteDto>();
            container.RegisterSingle<FabricaEquipamento, FabricaEquipamento>();
            container.RegisterSingle<FabricaEquipamentoDto, FabricaEquipamentoDto>();
            container.RegisterSingle<FabricaManutencao, FabricaManutencao>();
            container.RegisterSingle<FabricaManutencaoDto, FabricaManutencaoDto>();
            container.RegisterSingle<FabricaSumarioSituacaoDto, FabricaSumarioSituacaoDto>();
            container.RegisterSingle<FabricaPermissoes, FabricaPermissoes>();
            container.RegisterSingle<FabricaFatura, FabricaFatura>();
            container.RegisterSingle<FabricaFaturaDto, FabricaFaturaDto>();
            container.RegisterSingle<FabricaSiteDto, FabricaSiteDto>();
            container.RegisterSingle<CalculadoraSituacaoManutencao, CalculadoraSituacaoManutencao>();
            
            container.RegisterSingle<RepositorioEquipamentos, RepositorioEquipamentos>();
            container.RegisterSingle<RepositorioGrupos, RepositorioGrupos>();
            container.RegisterSingle<RepositorioUsuarios, RepositorioUsuarios>();
            container.RegisterSingle<RepositorioSites, RepositorioSites>();
            container.RegisterSingle<RepositorioClientes, RepositorioClientes>();
            container.RegisterSingle<RepositorioFaturas, RepositorioFaturas>();

            container.RegisterSingle<CriadorGrupo, CriadorGrupo>();
            container.RegisterSingle<ModificadorGrupo, ModificadorGrupo>();
            container.RegisterSingle<LocalizadorGrupo, LocalizadorGrupo>();
            container.RegisterSingle<CriadorUsuario, CriadorUsuario>();
            container.RegisterSingle<ModificadorUsuario, ModificadorUsuario>();
            container.RegisterSingle<LocalizadorUsuario, LocalizadorUsuario>();
            container.RegisterSingle<CriadorCliente, CriadorCliente>();
            container.RegisterSingle<ModificadorCliente, ModificadorCliente>();
            container.RegisterSingle<LocalizadorCliente, LocalizadorCliente>();
            container.RegisterSingle<CriadorEquipamento, CriadorEquipamento>();
            container.RegisterSingle<ModificadorEquipamento, ModificadorEquipamento>();
            container.RegisterSingle<LocalizadorEquipamento, LocalizadorEquipamento>();
            container.RegisterSingle<CriadorFatura, CriadorFatura>();
            container.RegisterSingle<LocalizadorFatura, LocalizadorFatura>();
            container.RegisterSingle<LocalizadorSite, LocalizadorSite>();

            container.RegisterSingle<FabricaValidadorEquipamento, FabricaValidadorEquipamento>();

            container.RegisterSingle<ConfigSeguranca, ConfigSeguranca>();
            container.RegisterSingle<GeradorDeSenha, GeradorDeSenha>();
            container.RegisterSingle<GeradorDeToken, GeradorDeToken>();
            container.RegisterSingle<ValidadorDeToken, ValidadorDeToken>();
            container.RegisterSingle<ConfiguradorPayPal, ConfiguradorPayPal>();
            container.RegisterSingle<IntegradorPayPal, IntegradorPayPal>();
            container.RegisterSingle<FabricaPagamentoPayPal, FabricaPagamentoPayPal>();
            container.RegisterSingle<Login, Login>();

            container.RegisterWebApiControllers(config);

            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}