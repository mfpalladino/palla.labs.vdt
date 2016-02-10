using MongoDB.Driver;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public abstract class RepositorioBase
    {
        protected RepositorioBase(IMongoClient mongoClient, ILeitorConfiguracoesBancoDeDados leitorConfiguracoesBancoDeDados)
        {
            MongoClient = mongoClient;
            LeitorConfiguracoesBancoDeDados = leitorConfiguracoesBancoDeDados;
        }

        protected IMongoClient MongoClient { get; private set; }
        protected ILeitorConfiguracoesBancoDeDados LeitorConfiguracoesBancoDeDados { get; private set; }

        protected IMongoDatabase MongoDatabase
        {
            get { return MongoClient.GetDatabase(LeitorConfiguracoesBancoDeDados.BancoDeDados); }
        }
    }
}