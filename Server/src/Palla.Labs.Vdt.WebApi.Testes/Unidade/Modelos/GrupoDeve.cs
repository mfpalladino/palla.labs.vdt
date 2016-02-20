using System;
using FluentAssertions;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Unidade.Modelos
{
    [TestFixture]
    public class GrupoDeve
    {
        [Test]
        public void GerarExcecaoQuandoNomeNaoForInformado()
        {
            //Arrange/action
            Action acao = () => new Grupo("");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoNomeTiverMaisDe50Caracteres()
        {
            //Arrange/action
            Action acao = () => new Grupo("1".PadRight(51, 'a'));

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }
    }
}
