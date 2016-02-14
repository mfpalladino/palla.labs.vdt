
using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Dominio.Servicos;
using Palla.Labs.Vdt.WebApi.Testes.Fabricas;

namespace Palla.Labs.Vdt.WebApi.Testes.Unidade.ServicosDominio
{
    [TestFixture]
    public class CalculadoraSituacaoManutencaoDeve
    {
        [Test]
        public void RetornarOkParaCentralAlarmePoisSuaManutencaoNaoEControladaPelasPartes()
        {
            //Arrange
            var equipamento = new ConstrutorCentralAlarme().Construir();

            //Action
            var situacaoCalculada = new CalculadoraSituacaoManutencao(equipamento).Calcular();

            //Asserts
            situacaoCalculada.Should().Be(SituacaoManutencao.Ok);
        }

        [Test]
        public void RetornarSituacaoCorretaParaEquipamentoConformeDataDeReferencia() 
        {
            //Arrange
            var extintorParaCasosDeTeste = new ConstrutorExtintor()
                .ComManutencao(new DateTime(2015, 2, 15))
                .ComManutencao(new DateTime(2016, 2, 13))
                .Construir();

            var casosDeTestePorEquipamentoDataReferencia = new Dictionary<Tuple<Equipamento, DateTime, string>, SituacaoManutencao>
            {
                {
                    new Tuple<Equipamento, DateTime, string>(
                        new ConstrutorExtintor().Construir(), 
                        DateTime.Now,
                        "Equipamento sem nenhuma manutenção deve retornar ok"), SituacaoManutencao.Ok
                },

                {
                    new Tuple<Equipamento, DateTime, string>(
                        extintorParaCasosDeTeste, 
                        new DateTime(2017,1,13), 
                        "Equipamento mantido há 11 meses deve retornar 'estado crítico'"), SituacaoManutencao.EstadoCritico
                },

                {
                    new Tuple<Equipamento, DateTime, string>(
                        extintorParaCasosDeTeste, 
                        new DateTime(2017,2,1), 
                        "Equipamento mantido há mais de 12 meses deve retornar 'estado crítico'"), SituacaoManutencao.EstadoCritico
                },

                {
                    new Tuple<Equipamento, DateTime, string>(
                        extintorParaCasosDeTeste, 
                        new DateTime(2016,12,14), 
                        "Equipamento mantido há mais de 10 meses deve retornar 'estado de atenção'"), SituacaoManutencao.EstadoDeAtencao
                },

                {
                    new Tuple<Equipamento, DateTime, string>(
                        extintorParaCasosDeTeste, 
                        new DateTime(2016,12,31), 
                        "Equipamento mantido há mais de 11 meses deve retornar 'estado de atenção'"), SituacaoManutencao.EstadoDeAtencao
                }

            };

            foreach (var caso in casosDeTestePorEquipamentoDataReferencia)
            {
                var equipamento = caso.Key.Item1;
                var dataReferenciaParaCalculoSituacao = caso.Key.Item2;
                var descricaoCasoDeTeste = caso.Key.Item3;
                var situacaoEsperada = caso.Value;

                //Action
                var situacaoCalculada = new CalculadoraSituacaoManutencao(equipamento)
                    .Calcular(dataReferenciaParaCalculoSituacao);

                //Asserts
                situacaoCalculada.Should().Be(situacaoEsperada, descricaoCasoDeTeste);
            }
        } 
    }
}
