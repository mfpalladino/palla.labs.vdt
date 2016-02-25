using System;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;
using Palla.Labs.Vdt.WebApi.Testes.Fabricas;

namespace Palla.Labs.Vdt.WebApi.Testes.Unidade.ServicosAplicacao
{
    [TestFixture]
    public class ModificadorGrupoDeve
    {
        [Test]
        public void GerarExcecaoQuandoIdNaoForValido()
        {
            //Arrange
            Action acao = () => new ModificadorGrupo(new Mock<RepositorioGrupos>().Object, new Mock<IMapper>().Object).Modificar("qualquer coisa", new GrupoDto());

            //Asserts
            acao.ShouldThrow<FormatoInvalido>();
        }

        [Test]
        public void GerarExcecaoQuandoGrupoSolicitadoNaoExistir()
        {
            //Arrange
            var id = Guid.NewGuid().ToString();
            var repositorio = new Mock<RepositorioGrupos>();
            repositorio.Setup(x => x.BuscarPorId(new Guid(id))).Throws<RecursoNaoEncontrado>();

            //Action
            Action acao = () => new ModificadorGrupo(repositorio.Object, new Mock<IMapper>().Object).Modificar(id, new GrupoDto());

            //Asserts
            acao.ShouldThrow<RecursoNaoEncontrado>();
        }

        [Test]
        public void FazerOEsperadoQuandoTudoEstiverOk()
        {
            //Arrange
            var repositorio = new Mock<RepositorioGrupos>();
            var mapper = new Mock<IMapper>();

            var id = Guid.NewGuid();
            var grupoEsperado = new ConstrutorGrupo().Construir();
            var grupoRecebido = new GrupoDto {Id = id, Nome = "Grupo"};

            repositorio.Setup(x => x.BuscarPorId(It.IsAny<Guid>())).Returns(grupoEsperado);
            repositorio.Setup(x => x.Editar(grupoEsperado));
            mapper.Setup(x => x.Map<Grupo>(grupoRecebido)).Returns(grupoEsperado);

            //Action
            Action acao = () => new ModificadorGrupo(repositorio.Object, mapper.Object).Modificar(id.ToString(), grupoRecebido);

            //Asserts
            acao.ShouldNotThrow();
        }
    }
}
