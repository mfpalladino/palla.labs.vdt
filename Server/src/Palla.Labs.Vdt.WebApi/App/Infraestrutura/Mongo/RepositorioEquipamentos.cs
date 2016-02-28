using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioEquipamentos : RepositorioBase
    {
        private const string NOME_COLECAO = "equipamentos";

        public RepositorioEquipamentos(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
            : base(mongoClient, configBancoDados)
        {
        }

        public void Inserir(Equipamento equipamento)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NOME_COLECAO);
            colecao.InsertOne(equipamento);
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

        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<Equipamento>(NOME_COLECAO);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}