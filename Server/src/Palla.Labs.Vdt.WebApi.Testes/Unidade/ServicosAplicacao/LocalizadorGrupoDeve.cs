using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Dominio.Modelos;
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
            Action acao = () => new LocalizadorGrupo(new Mock<RepositorioGrupos>().Object, new Mock<FabricaGrupoDto>().Object,
                new Mock<FabricaSumarioSituacaoDto>().Object).Localizar(Guid.NewGuid(), "qualquer coisa");

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoGrupoSolicitadoNaoExistir()
        {
            //Arrange
            var id = Guid.NewGuid().ToString();
            var repositorio = new Mock<RepositorioGrupos>();
            repositorio.Setup(x => x.BuscarPorId(Guid.NewGuid(), new Guid(id))).Throws<RecursoNaoEncontrado>();

            //Action
            Action acao = () => new LocalizadorGrupo(repositorio.Object, new Mock<FabricaGrupoDto>().Object, new Mock<FabricaSumarioSituacaoDto>().Object).Localizar(Guid.NewGuid(), id);

            //Asserts
            acao.ShouldThrow<RecursoNaoEncontrado>();
        }

        [Test]
        public void LocalizarCorretamentePorIdQuandoTudoEstiverOk()
        {
            //Arrange
            var repositorio = new Mock<RepositorioGrupos>();
            var mapper = new Mock<FabricaGrupoDto>();

            var id = Guid.NewGuid();
            var grupoEsperado = new Grupo(id, "Grupo");
            var grupoRetornadoMapper = new GrupoDto { Id = grupoEsperado.Id, Nome = grupoEsperado.Nome };

            repositorio.Setup(x => x.BuscarPorId(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(grupoEsperado);
            mapper.Setup(x => x.Criar(It.IsAny<Grupo>())).Returns(grupoRetornadoMapper);

            //Action
            var grupoRetornado = new LocalizadorGrupo(repositorio.Object, mapper.Object, new Mock<FabricaSumarioSituacaoDto>().Object).Localizar(Guid.NewGuid(), id.ToString());

            //Asserts
            grupoRetornado.Id.Should().Be(grupoEsperado.Id);
            grupoRetornado.Nome.Should().BeEquivalentTo(grupoEsperado.Nome);
        }

        [Test]
        public void LocalizarCorretamenteTodosQuandoTudoEstiverOk()
        {
            //Arrange
            var repositorio = new Mock<RepositorioGrupos>();
            var mapper = new Mock<FabricaGrupoDto>();

            var id = Guid.NewGuid();
            var grupoRetornadoDoBanco = new Grupo(id, "Grupo");
            var gruposRetornadosDoBanco = new List<Grupo> { grupoRetornadoDoBanco };
            var grupoRetornadoMapper = new GrupoDto { Id = grupoRetornadoDoBanco.Id, Nome = grupoRetornadoDoBanco.Nome };
            var gruposRetornadosMapper = new List<GrupoDto> { grupoRetornadoMapper };

            repositorio.Setup(x => x.Buscar(Guid.NewGuid(), null)).Returns(gruposRetornadosDoBanco);
            mapper.Setup(x => x.Criar(It.IsAny<IEnumerable<Grupo>>())).Returns(gruposRetornadosMapper);

            //Action
            var gruposRetornados = new LocalizadorGrupo(repositorio.Object, mapper.Object, new Mock<FabricaSumarioSituacaoDto>().Object).Localizar(Guid.NewGuid());

            //Asserts
            gruposRetornados.Where(x => x.Id == grupoRetornadoDoBanco.Id).Should().NotBeNullOrEmpty();
        }
    }
}