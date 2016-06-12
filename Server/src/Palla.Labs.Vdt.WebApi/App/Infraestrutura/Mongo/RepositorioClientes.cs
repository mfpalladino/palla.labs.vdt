using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioClientes : RepositorioBase
    {
        private const string NomeColecao = "clientes";

        public RepositorioClientes(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
            : base(mongoClient, configBancoDados)
        {
        }

        public void Inserir(Cliente cliente)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NomeColecao);
            colecao.InsertOne(cliente);
        }

        public virtual void Editar(Cliente cliente)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NomeColecao);
            colecao.ReplaceOne(Builders<Cliente>.Filter.Eq(x => x.Id, cliente.Id), cliente);
        }

        public IEnumerable<Cliente> Buscar(Guid siteId)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId).SortBy(x => x.Nome).ToList();
        }

        public Cliente BuscarPorId(Guid siteId, Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Id == id).FirstOrDefault();
        }

        public Cliente BuscarPorCnpj(Guid siteId, Cnpj cnpj)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Cnpj == cnpj).FirstOrDefault();
        }

        public Cliente BuscarPorCodigo(Guid siteId, string codigo)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Codigo.ToLower() == codigo.ToLower()).FirstOrDefault();
        }

        public Cliente BuscarPorNome(Guid siteId, string nome)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Codigo.ToLower() == nome.ToLower()).FirstOrDefault();
        }

        public Cliente BuscarPorCnpjExcetoId(Guid siteId, Cnpj cnpj, Guid excetoId)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Cnpj == cnpj && x.Id != excetoId).FirstOrDefault();
        }

        public Cliente BuscarPorCodigoExcetoId(Guid siteId, string codigo, Guid excetoId)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Codigo.ToLower() == codigo.ToLower() && x.Id != excetoId).FirstOrDefault();
        }

        public Cliente BuscarPorNomeExcetoId(Guid siteId, string nome, Guid excetoId)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Codigo.ToLower() == nome.ToLower() && x.Id != excetoId).FirstOrDefault();
        }
        
        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Cliente>(NomeColecao);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}