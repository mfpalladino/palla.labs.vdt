using System;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioSites : RepositorioBase
    {
        private const string NomeColecao = "sites";

        public RepositorioSites(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
            : base(mongoClient, configBancoDados)
        {
        }

        public Site BuscarPorId(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Site>(NomeColecao);
            return colecao.Find(x => x.Id == id).FirstOrDefault();
        }

        public Site BuscarPorNome(string nome)
        {
            var colecao = MongoDatabase.GetCollection<Site>(NomeColecao);
            return colecao.Find(x => x.Nome.ToLower() == nome.ToLower()).FirstOrDefault();
        }
    }
}