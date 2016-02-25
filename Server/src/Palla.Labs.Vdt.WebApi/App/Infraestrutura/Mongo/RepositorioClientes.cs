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

        public IEnumerable<Cliente> Buscar()
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => true).SortBy(x => x.Nome).ToList();
        }

        public Cliente BuscarPorId(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Id == id).FirstOrDefault();
        }

        public Cliente BuscarPorCnpj(Cnpj cnpj)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Cnpj == cnpj).FirstOrDefault();
        }

        public Cliente BuscarPorCodigo(string codigo)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Codigo.ToLower() == codigo.ToLower()).FirstOrDefault();
        }

        public Cliente BuscarPorNome(string nome)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Codigo.ToLower() == nome.ToLower()).FirstOrDefault();
        }

        public Cliente BuscarPorCnpjExcetoId(Cnpj cnpj, Guid excetoId)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Cnpj == cnpj && x.Id != excetoId).FirstOrDefault();
        }

        public Cliente BuscarPorCodigoExcetoId(string codigo, Guid excetoId)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Codigo.ToLower() == codigo.ToLower() && x.Id != excetoId).FirstOrDefault();
        }

        public Cliente BuscarPorNomeExcetoId(string nome, Guid excetoId)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            return colecao.Find(x => x.Codigo.ToLower() == nome.ToLower() && x.Id != excetoId).FirstOrDefault();
        }
        
        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}