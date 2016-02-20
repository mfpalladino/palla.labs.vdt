using System;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

namespace Palla.Labs.Vdt.WebApi.Testes.Unidade.ServicosAplicacao
{
    [TestFixture]
    public class ModificadorGrupoDeve
    {
        [Test]
        public void GerarExcecaoQuandoIdNaoForValido()
        {
            //Arrange
            Action acao = () => new ModificadorGrupo(new Mock<RepositorioGrupos>().Object, new Mock<IMapper>().Object).Modificar("qualquer coisa", new Grupo());

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
            Action acao = () => new ModificadorGrupo(repositorio.Object, new Mock<IMapper>().Object).Modificar(id, new Grupo());

            //Asserts
            acao.ShouldThrow<RecursoNaoEncontrado>();
        }
    }
}
