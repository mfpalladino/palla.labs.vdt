using System;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao;

namespace Palla.Labs.Vdt.WebApi.Testes.Unidade.ServicosAplicacao
{
    [TestFixture]
    public class LocalizadorGrupoDeve
    {
        [Test]
        public void GerarExcecaoQuandoIdNaoForValido()
        {
            //Arrange
            Action acao = () => new LocalizadorGrupo(new Mock<RepositorioGrupos>().Object, new Mock<IMapper>().Object).Localizar("qualquer coisa");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoGrupoSolicitadoNaoExistir()
        {
            //Arrange
            var id = Guid.NewGuid().ToString();
            var repositorio = new Mock<RepositorioGrupos>();
            repositorio.Setup(x => x.ListarPorId(new Guid(id))).Throws<RecursoNaoEncontrado>();

            //Action
            Action acao = () => new LocalizadorGrupo(repositorio.Object, new Mock<IMapper>().Object).Localizar(id);

            //Asserts
            acao.ShouldThrow<RecursoNaoEncontrado>();
        }
    }
}