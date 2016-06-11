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

        public virtual IEnumerable<Grupo> Buscar()
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NomeColecao);
            return colecao.Find(x => true).SortBy(x => x.Nome).ToList();
        }

        public virtual Grupo BuscarPorId(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NomeColecao);
            return colecao.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NomeColecao);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}