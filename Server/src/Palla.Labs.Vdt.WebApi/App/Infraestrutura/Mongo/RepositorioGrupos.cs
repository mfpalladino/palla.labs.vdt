using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioGrupos : RepositorioBase
    {
        private const string NomeColecao = "grupos";

        protected RepositorioGrupos() //usado penas para testes
        {
        }

        public RepositorioGrupos(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
            : base(mongoClient, configBancoDados)
        {
        }

        public void Inserir(Grupo grupo)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NomeColecao);
            colecao.InsertOne(grupo);
        }

        public virtual void Editar(Grupo grupo)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NomeColecao);
            colecao.ReplaceOne(Builders<Grupo>.Filter.Eq(x => x.Id, grupo.Id), grupo);

        }

        public virtual IEnumerable<Grupo> Buscar(Guid siteId, Guid[] gruposId = null)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NomeColecao);

            if (gruposId == null)
                return colecao.Find(x => x.SiteId == siteId).SortBy(x => x.Nome).ToList();

            return colecao.Find(Builders<Grupo>.Filter
                .And(
                    Builders<Grupo>.Filter.Eq(y=>y.SiteId, siteId),
                    Builders<Grupo>.Filter.In(y => y.Id, gruposId)
                )).ToList();
        }

        public virtual Grupo BuscarPorId(Guid siteId, Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Id == id).FirstOrDefault();
        }

        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NomeColecao);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}