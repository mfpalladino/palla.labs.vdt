using System;
using FluentAssertions;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Unidade.Modelos
{
    [TestFixture]
    public class CnpjDeve
    {
        [Test]
        public void GerarExcecaoQuandoCnpjForVazio()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Cnpj("");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoCnpjForMaiorQueOPermitido()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Cnpj("1".PadRight(15, '1'));

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoCnpjTiverAlgoAlemDeNumeros()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Cnpj("123abc");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }
    }
}