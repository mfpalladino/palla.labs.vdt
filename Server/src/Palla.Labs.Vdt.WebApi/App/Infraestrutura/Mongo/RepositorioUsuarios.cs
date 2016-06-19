using System;
using System.Collections.Generic;
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

        public void Inserir(Usuario usuario)
        {
            var colecao = MongoDatabase.GetCollection<Usuario>(NomeColecao);
            colecao.InsertOne(usuario);
        }

        public virtual void Editar(Usuario usuario)
        {
            var colecao = MongoDatabase.GetCollection<Usuario>(NomeColecao);
            colecao.ReplaceOne(Builders<Usuario>.Filter.Eq(x => x.Id, usuario.Id), usuario);
        }

        public IEnumerable<Usuario> Buscar(Guid siteId)
        {
            var colecao = MongoDatabase.GetCollection<Usuario>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId).ToList();
        }

        public Usuario BuscarPorId(Guid siteId, Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Usuario>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Id == id).FirstOrDefault();
        }

        public Usuario BuscarPorNome(Guid siteId, string nome)
        {
            var colecao = MongoDatabase.GetCollection<Usuario>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Nome.ToLower() == nome.ToLower()).FirstOrDefault();
        }
    }
}