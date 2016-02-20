﻿using System.Linq;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao;
using Palla.Labs.Vdt.WebApi.Testes.Fabricas;

namespace Palla.Labs.Vdt.WebApi.Testes.Integracao.ServicosAplicacao
{
    [TestFixture]
    public class CriadorManutencaoDeve
    {
        [Test]
        public void InserirManutencaoDeUmaParte()
        {
            var leitorConfiguracoes = new ConfigBancoDadosVariavelAmbienteTestes();
            var repositorio = new RepositorioEquipamentos(new MongoClient(leitorConfiguracoes.StringConexao), leitorConfiguracoes);
            var servico = new CriadorManutencao(repositorio);

            Extintor extintor = null;
            try
            {
                extintor = new ConstrutorExtintor().Construir();
                repositorio.Inserir(extintor);

                var nomeParteParaManutencao = extintor.ParametrosManutencao.Partes.First().Nome;
                servico.Criar(extintor.Id, nomeParteParaManutencao);

                var extintorAposAManutencao = repositorio.ListarPorId(extintor.Id);

                extintorAposAManutencao.Manutencoes.Should().HaveCount(1);
                extintorAposAManutencao.Manutencoes.First().Parte.Should().Be(nomeParteParaManutencao);
            }
            finally
            {
                if (extintor != null)
                    repositorio.Remover(extintor.Id);
            }
        }
    }
}