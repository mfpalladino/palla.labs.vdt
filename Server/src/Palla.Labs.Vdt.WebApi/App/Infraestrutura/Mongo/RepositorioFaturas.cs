using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class RepositorioFaturas : RepositorioBase
    {
        private const string NomeColecao = "faturas";

        protected RepositorioFaturas() //usado penas para testes
        {
        }

        public RepositorioFaturas(IMongoClient mongoClient, IConfigBancoDados configBancoDados)
            : base(mongoClient, configBancoDados)
        {
        }

        public void Inserir(Fatura fatura)
        {
            var colecao = MongoDatabase.GetCollection<Fatura>(NomeColecao);
            colecao.InsertOne(fatura);
        }

        public virtual IEnumerable<Fatura> Buscar(Guid siteId)
        {
            var colecao = MongoDatabase.GetCollection<Fatura>(NomeColecao);
            return
                colecao.Find(x => x.SiteId == siteId)
                    .Sort(new SortDefinitionBuilder<Fatura>().Descending(x => x.Ano).Descending(x => x.Mes))
                    .ToList();
        }
    }
}