using System.Web.Http;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Dominio.Servicos;
using Palla.Labs.Vdt.App.Infraestrutura.Json;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
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
            container.RegisterSingle<FabricaCliente, FabricaCliente>();
            container.RegisterSingle<FabricaClienteDto, FabricaClienteDto>();
            container.RegisterSingle<FabricaEquipamento, FabricaEquipamento>();
            container.RegisterSingle<FabricaEquipamentoDto, FabricaEquipamentoDto>();
            container.RegisterSingle<FabricaManutencao, FabricaManutencao>();
            container.RegisterSingle<FabricaManutencaoDto, FabricaManutencaoDto>();
            container.RegisterSingle<CalculadoraSituacaoManutencao, CalculadoraSituacaoManutencao>();

            container.RegisterSingle<RepositorioEquipamentos, RepositorioEquipamentos>();
            container.RegisterSingle<RepositorioGrupos, RepositorioGrupos>();

            container.RegisterSingle<CriadorGrupo, CriadorGrupo>();
            container.RegisterSingle<ModificadorGrupo, ModificadorGrupo>();
            container.RegisterSingle<LocalizadorGrupo, LocalizadorGrupo>();
            container.RegisterSingle<CriadorCliente, CriadorCliente>();
            container.RegisterSingle<ModificadorCliente, ModificadorCliente>();
            container.RegisterSingle<LocalizadorCliente, LocalizadorCliente>();

            container.RegisterSingle<FabricaValidadorEquipamento, FabricaValidadorEquipamento>();

            container.RegisterSingle<CriadorEquipamento, CriadorEquipamento>();
            container.RegisterSingle<LocalizadorEquipamento, LocalizadorEquipamento>();

            container.RegisterWebApiControllers(config);

            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}