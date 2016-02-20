using MongoDB.Driver;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public abstract class RepositorioBase
    {
        protected RepositorioBase() //usado penas para testes
        {
        }

        protected RepositorioBase(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
        {
            MongoClient = mongoClient;
            ConfigBancoDados = configBancoDados;
        }

        protected IMongoClient MongoClient { get; private set; }
        protected IConfigBancoDados ConfigBancoDados { get; private set; }

        protected IMongoDatabase MongoDatabase
        {
            get { return MongoClient.GetDatabase(ConfigBancoDados.NomeBancoDados); }
        }
    }
}