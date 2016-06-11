using System;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioUsuarios : RepositorioBase
    {
        private const string NomeColecao = "usuarios";

        public RepositorioUsuarios(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
            : base(mongoClient, configBancoDados)
        {
        }

        public Usuario BuscarPorId(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Usuario>(NomeColecao);
            return colecao.Find(x => x.Id == id).FirstOrDefault();
        }

        public Usuario BuscarPorNome(Guid siteId, string nome)
        {
            var colecao = MongoDatabase.GetCollection<Usuario>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Nome.ToLower() == nome.ToLower()).FirstOrDefault();
        }
    }
}