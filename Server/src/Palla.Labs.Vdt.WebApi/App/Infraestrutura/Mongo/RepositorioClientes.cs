using System;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioClientes : RepositorioBase
    {
        private const string NOME_COLECAO = "clientes";

        public RepositorioClientes(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
            : base(mongoClient, configBancoDados)
        {
        }

        public void Inserir(Cliente cliente)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            colecao.InsertOne(cliente);
        }

        public Cliente ListarPorId(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}