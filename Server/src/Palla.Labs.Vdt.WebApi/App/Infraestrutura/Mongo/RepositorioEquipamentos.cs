using System;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos.Equipamento;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioEquipamentos : RepositorioBase
    {
        private const string NOME_COLECAO = "equipamentos";

        public RepositorioEquipamentos(IMongoClient mongoClient, ILeitorConfiguracoesBancoDeDados leitorConfiguracoesBancoDeDados)
            : base(mongoClient, leitorConfiguracoesBancoDeDados)
        {
        }

        public void Inserir(EquipamentoBase equipamento)
        {
            var colecao = MongoDatabase.GetCollection<EquipamentoBase>(NOME_COLECAO);
            colecao.InsertOne(equipamento);
        }

        public EquipamentoBase ListarPorId(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<EquipamentoBase>(NOME_COLECAO);
            return colecao.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Remover(Guid id)
        {
            var colecao = MongoDatabase.GetCollection<EquipamentoBase>(NOME_COLECAO);
            colecao.DeleteOne(x => x.Id == id);
        }
    }
}