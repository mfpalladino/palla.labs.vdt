using System.Web.Http;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
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
            container.RegisterSingle<RepositorioEquipamentos, RepositorioEquipamentos>();
            container.RegisterSingle<RepositorioGrupos, RepositorioGrupos>();
            container.RegisterSingle<CriadorGrupo, CriadorGrupo>();
            container.RegisterSingle<ModificadorGrupo, ModificadorGrupo>();
            container.RegisterSingle<LocalizadorGrupo, LocalizadorGrupo>();

            container.RegisterWebApiControllers(config);

            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}