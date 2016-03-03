using System.Web.Http;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Palla.Labs.Vdt
{
    public static class IoC
    {
        private static readonly Container Container = new Container();

        public static void Configurar(HttpConfiguration config)
        {
            var leitorConfiguracoes = new ConfigBancoDadosArquivo();

            Container.RegisterSingle<IConfigBancoDados>(leitorConfiguracoes);
            Container.RegisterSingle<IMongoClient>(new MongoClient(leitorConfiguracoes.StringConexao));

            Container.RegisterSingle<FabricaGrupo, FabricaGrupo>();
            Container.RegisterSingle<FabricaGrupoDto, FabricaGrupoDto>();
            Container.RegisterSingle<FabricaCliente, FabricaCliente>();
            Container.RegisterSingle<FabricaClienteDto, FabricaClienteDto>();
            Container.RegisterSingle<FabricaEquipamento, FabricaEquipamento>();
            Container.RegisterSingle<FabricaEquipamentoDto, FabricaEquipamentoDto>();

            Container.RegisterSingle<RepositorioEquipamentos, RepositorioEquipamentos>();
            Container.RegisterSingle<RepositorioGrupos, RepositorioGrupos>();

            Container.RegisterSingle<CriadorGrupo, CriadorGrupo>();
            Container.RegisterSingle<ModificadorGrupo, ModificadorGrupo>();
            Container.RegisterSingle<LocalizadorGrupo, LocalizadorGrupo>();
            Container.RegisterSingle<CriadorCliente, CriadorCliente>();
            Container.RegisterSingle<ModificadorCliente, ModificadorCliente>();
            Container.RegisterSingle<LocalizadorCliente, LocalizadorCliente>();

            Container.RegisterSingle<FabricaValidadorEquipamento, FabricaValidadorEquipamento>();

            Container.RegisterSingle<CriadorEquipamento, CriadorEquipamento>();
            Container.RegisterSingle<LocalizadorEquipamento, LocalizadorEquipamento>();

            Container.RegisterWebApiControllers(config);

            Container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
        }

        public static T GetInstance<T>() where T : class
        {
            return Container.GetInstance<T>();
        }
    }
}