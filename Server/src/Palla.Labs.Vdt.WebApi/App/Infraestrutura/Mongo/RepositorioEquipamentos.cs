using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioEquipamentos : RepositorioBase
    {
        private const string NomeColecao = "equipamentos";
        private const string NomeColecaoClientes = "clientes";

        public RepositorioEquipamentos(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
            : base(mongoClient, configBancoDados)
        {
        }

        public void Inserir(Equipamento equipamento)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NomeColecao);
            colecao.InsertOne(equipamento);
        }

        public virtual void Editar(Equipamento equipamento)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NomeColecao);
            colecao.ReplaceOne(Builders<Equipamento>.Filter.Eq(x => x.Id, equipamento.Id), equipamento);

        }

        public void InserirManutencao(Equipamento equipamento, Manutencao manutencao)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NomeColecao);
            colecao.FindOneAndUpdate(Builders<Equipamento>.Filter.Eq(x => x.Id, equipamento.Id), 
                Builders<Equipamento>.Update.AddToSet(x => x.Manutencoes, manutencao));
        }

        public IEnumerable<Equipamento> Buscar(Guid siteId)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId).ToList();
        }

        public Equipamento BuscarPorId(Guid siteId, Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Equipamento> BuscarPorGrupo(Guid siteId, Guid grupoId)
        {
            var colecaoClientes = MongoDatabase.GetCollection<Cliente>(NomeColecaoClientes);
            var idsClientes = colecaoClientes.Find(x => x.SiteId == siteId && x.GrupoId == grupoId).ToList().Select(x => x.Id);

            var colecaoEquipamentos = MongoDatabase.GetCollection<Equipamento>(NomeColecao);
            
            return colecaoEquipamentos.Find(Builders<Equipamento>.Filter.In(x => x.ClienteId, idsClientes)).ToList();
        }

        public IEnumerable<Equipamento> BuscarPorCliente(Guid siteId, Guid clienteId)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NomeColecao);
            return colecao.Find(x => x.SiteId == siteId && x.ClienteId == clienteId).ToList();
        }

        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NomeColecao);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}