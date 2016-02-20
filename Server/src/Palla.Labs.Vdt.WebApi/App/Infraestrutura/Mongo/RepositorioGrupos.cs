using System;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioGrupos : RepositorioBase
    {
        private const string NOME_COLECAO = "grupos";

        public RepositorioGrupos(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
            : base(mongoClient, configBancoDados)
        {
        }

        public void Inserir(Grupo grupo)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NOME_COLECAO);
            colecao.InsertOne(grupo);
        }

        public Grupo ListarPorId(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NOME_COLECAO);
            return colecao.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Grupo>(NOME_COLECAO);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}