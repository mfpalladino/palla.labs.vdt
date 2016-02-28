using System;
using FluentAssertions;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Unidade.Modelos
{
    [TestFixture]
    public class EnderecoDeve
    {
        [Test]
        public void GerarExcecaoQuandoLogradouroForVazio()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("", "numero", "complemento", "bairro", "cidade", "SP", "cep");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoLogradouroForMaiorQueOPermitido()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("1".PadRight(201, 'a'), "numero", "complemento", "bairro", "cidade", "SP", "cep");


            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoNumeroForVazio()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", null, "complemento", "bairro", "cidade", "SP", "cep");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoNumeroForMaiorQueOPermitido()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", "1".PadRight(21, 'a'), "complemento", "bairro", "cidade", "SP", "cep");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoComplementoForMaiorQueOPermitido()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", "numero", "1".PadRight(101, 'a'), "bairro", "cidade", "SP", "cep");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoBairroForVazio()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", "numero", "complemento", "", "cidade", "SP", "cep");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoBairroForMaiorQueOPermitido()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", "numero", "complemento", "1".PadRight(121, 'a'), "cidade", "SP", "cep");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoCidadeForVazio()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", "numero", "complemento", "bairro", null, "SP", "cep");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoCidadeForMaiorQueOPermitido()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", "numero", "complemento", "bairro", "1".PadRight(81, 'a'), "SP", "cep");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoEstadoForVazio()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", "numero", "complemento", "bairro", "cidade", "", "cep");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoEstadoForMaiorQueOPermitido()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", "numero", "complemento", "bairro", "cidade", "SP1", "cep");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoCepForVazio()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", "numero", "complemento", "bairro", "cidade", "estado", "");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoCepForMaiorQueOPermitido()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", "numero", "complemento", "bairro", "cidade", "SP1", "12345678901");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoCepTiverAlgoAlemDeDigitos()
        {
            //Arrange/action
            // ReSharper disable once ObjectCreationAsStatement
            Action acao = () => new Endereco("logradouro", "numero", "complemento", "bairro", "cidade", "SP1", "123cep");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }
    }
}
