using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioGrupos : RepositorioBase
    {
        private const string NOME_COLECAO = "grupos";

        protected RepositorioGrupos() //usado penas para testes
        {
        }

        public RepositorioGrupos(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
            : base(mongoClient, configBancoDados)
        {
        }

        public void Inserir(Grupo grupo)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NOME_COLECAO);
            colecao.InsertOne(grupo);
        }

        public void Editar(Grupo grupo)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NOME_COLECAO);
            colecao.ReplaceOne(Builders<Grupo>.Filter.Eq(x => x.Id, grupo.Id), grupo);

        }

        public virtual Grupo ListarPorId(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NOME_COLECAO);
            return colecao.Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Grupo> ListarTodos()
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NOME_COLECAO);
            return colecao.Find(x => true).SortBy(x => x.Nome).ToList();
        }

        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NOME_COLECAO);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}