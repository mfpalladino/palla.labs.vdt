using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioEquipamentos : RepositorioBase
    {
        private const string NOME_COLECAO = "equipamentos";
        private const string NOME_COLECAO_CLIENTES = "clientes";

        public RepositorioEquipamentos(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
            : base(mongoClient, configBancoDados)
        {
        }

        public void Inserir(Equipamento equipamento)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NOME_COLECAO);
            colecao.InsertOne(equipamento);
        }

        public virtual void Editar(Equipamento equipamento)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NOME_COLECAO);
            colecao.ReplaceOne(Builders<Equipamento>.Filter.Eq(x => x.Id, equipamento.Id), equipamento);

        }

        public void InserirManutencao(Equipamento equipamento, Manutencao manutencao)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NOME_COLECAO);
            colecao.FindOneAndUpdate(Builders<Equipamento>.Filter.Eq(x => x.Id, equipamento.Id), 
                Builders<Equipamento>.Update.AddToSet(x => x.Manutencoes, manutencao));
        }

        public IEnumerable<Equipamento> Buscar()
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NOME_COLECAO);
            return colecao.Find(x => true).ToList();
        }

        public Equipamento BuscarPorId(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NOME_COLECAO);
            return colecao.Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Equipamento> BuscarPorGrupo(Guid grupoId)
        {
            var colecaoClientes = MongoDatabase.GetCollection<Cliente>(NOME_COLECAO_CLIENTES);
            var idsClientes = colecaoClientes.Find(x => x.GrupoId == grupoId).ToList().Select(x => x.Id);

            var colecaoEquipamentos = MongoDatabase.GetCollection<Equipamento>(NOME_COLECAO);
            return colecaoEquipamentos.Find(Builders<Equipamento>.Filter.In(x => x.ClienteId, idsClientes)).ToList();
        }

        public IEnumerable<Equipamento> BuscarPorCliente(Guid clienteId)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NOME_COLECAO);
            return colecao.Find(x => x.ClienteId == clienteId).ToList();
        }

        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NOME_COLECAO);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}