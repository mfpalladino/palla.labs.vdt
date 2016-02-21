using System.Net;
using FluentAssertions;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

namespace Palla.Labs.Vdt.WebApi.Testes.Unidade.Excecoes
{
    [TestFixture]
    public class ExcecaoParaHttpStatusCodeDeve
    {
        [Test]
        public void Retornar400ParaFormatoInvalido()
        {
            ExcecaoParaHttpStatusCode.Dicionario()[typeof (FormatoInvalido)].Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public void Retornar404ParaRecursoNaoEncontrado()
        {
            ExcecaoParaHttpStatusCode.Dicionario()[typeof(RecursoNaoEncontrado)].Should().Be(HttpStatusCode.NotFound);
        }

        [Test]
        public void Retornar409ParaRecursoJaExistenteComAsMesmasCaracteristicas()
        {
            ExcecaoParaHttpStatusCode.Dicionario()[typeof(JaExisteUmRecursoComEstasCaracteristicas)].Should().Be(HttpStatusCode.Conflict);
        }
    }
}
