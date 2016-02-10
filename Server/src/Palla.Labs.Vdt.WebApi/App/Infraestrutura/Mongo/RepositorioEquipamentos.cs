using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos.Equipamento;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioEquipamentos
    {
        private const string NOME_COLECAO = "equipamentos";

        public void Inserir(EquipamentoBase equipamento)
        {
            var client = new MongoClient(PegaStringConexao());
            var db = client.GetDatabase(PegaBancoDeDados());
            var collection = db.GetCollection<EquipamentoBase>(NOME_COLECAO);
            collection.InsertOne(equipamento);
        }

        public IReadOnlyList<EquipamentoBase> ListarTodos() //apenas para testes
        {
            var client = new MongoClient(PegaStringConexao());
            var db = client.GetDatabase(PegaBancoDeDados());
            var collection = db.GetCollection<EquipamentoBase>(NOME_COLECAO);
            return new ReadOnlyCollection<EquipamentoBase>(collection.Find(x => true).ToList());
        }

        public void Remover(Guid id)
        {
            var client = new MongoClient(PegaStringConexao());
            var db = client.GetDatabase(PegaBancoDeDados());
            var collection = db.GetCollection<EquipamentoBase>(NOME_COLECAO);
            collection.DeleteOne(x => x.Id == id);
        }

        private static string PegaStringConexao()
        {
            return Environment.GetEnvironmentVariable("string-conexao") ?? ConfigurationManager.AppSettings["string-conexao"];
        }

        private static string PegaBancoDeDados()
        {
            return Environment.GetEnvironmentVariable("banco-de-dados") ?? ConfigurationManager.AppSettings["banco-de-dados"];
        }
    }
}