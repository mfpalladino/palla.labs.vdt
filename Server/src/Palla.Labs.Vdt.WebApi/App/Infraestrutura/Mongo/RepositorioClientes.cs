using System;
using System.Collections.Generic;
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

        public virtual void Editar(Cliente cliente)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            colecao.ReplaceOne(Builders<Cliente>.Filter.Eq(x => x.Id, cliente.Id), cliente);
        }

        public Cliente ListarPorId(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Id == id).FirstOrDefault();
        }

        public Cliente ListarPorCnpj(Cnpj cnpj)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Cnpj == cnpj).FirstOrDefault();
        }

        public Cliente ListarPorCodigo(string codigo)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Codigo.ToLower() == codigo.ToLower()).FirstOrDefault();
        }

        public Cliente ListarPorNome(string nome)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Codigo.ToLower() == nome.ToLower()).FirstOrDefault();
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => true).SortBy(x => x.Nome).ToList();
        }

        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}