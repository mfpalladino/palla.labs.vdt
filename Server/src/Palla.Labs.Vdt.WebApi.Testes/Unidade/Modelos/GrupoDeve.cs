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
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Grupo(Guid.NewGuid(), "");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoNomeTiverMaisDe50Caracteres()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Grupo(Guid.NewGuid(), Guid.NewGuid(), "1".PadRight(51, 'a'));

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }
    }
}
