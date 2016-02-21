using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

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

        [Test]
        public void LocalizarCorretamentePorIdQuandoTudoEstiverOk()
        {
            //Arrange
            var repositorio = new Mock<RepositorioGrupos>();
            var mapper = new Mock<IMapper>();

            var id = Guid.NewGuid();
            var grupoEsperado = new Grupo(id, "Grupo");
            var grupoRetornadoMapper = new GrupoDto { Id = grupoEsperado.Id, Nome = grupoEsperado.Nome };

            repositorio.Setup(x => x.ListarPorId(It.IsAny<Guid>())).Returns(grupoEsperado);
            mapper.Setup(x => x.Map<GrupoDto>(It.IsAny<Grupo>())).Returns(grupoRetornadoMapper);

            //Action
            var grupoRetornado = new LocalizadorGrupo(repositorio.Object, mapper.Object).Localizar(id.ToString());

            //Asserts
            grupoRetornado.Id.Should().Be(grupoEsperado.Id);
            grupoRetornado.Nome.Should().BeEquivalentTo(grupoEsperado.Nome);
        }

        [Test]
        public void LocalizarCorretamenteTodosQuandoTudoEstiverOk()
        {
            //Arrange
            var repositorio = new Mock<RepositorioGrupos>();
            var mapper = new Mock<IMapper>();

            var id = Guid.NewGuid();
            var grupoRetornadoDoBanco = new Grupo(id, "Grupo");
            var gruposRetornadosDoBanco = new List<Grupo> { grupoRetornadoDoBanco };
            var grupoRetornadoMapper = new GrupoDto { Id = grupoRetornadoDoBanco.Id, Nome = grupoRetornadoDoBanco.Nome };
            var gruposRetornadosMapper = new List<GrupoDto> { grupoRetornadoMapper };

            repositorio.Setup(x => x.ListarTodos()).Returns(gruposRetornadosDoBanco);
            mapper.Setup(x => x.Map<IEnumerable<GrupoDto>>(It.IsAny<IEnumerable<Grupo>>())).Returns(gruposRetornadosMapper);

            //Action
            var gruposRetornados = new LocalizadorGrupo(repositorio.Object, mapper.Object).Localizar();

            //Asserts
            gruposRetornados.Where(x => x.Id == grupoRetornadoDoBanco.Id).Should().NotBeNullOrEmpty();
        }
    }
}