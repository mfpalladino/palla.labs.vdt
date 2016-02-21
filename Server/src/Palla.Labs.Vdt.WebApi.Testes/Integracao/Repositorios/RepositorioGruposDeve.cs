using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.WebApi.Testes.Fabricas;

namespace Palla.Labs.Vdt.WebApi.Testes.Integracao.Repositorios
{
    [TestFixture]
    public class RepositorioGruposDeve
    {
        [Test]
        public void FazerOBasicoCorretamente()
        {
            var leitorConfiguracoes = new ConfigBancoDadosVariavelAmbienteTestes();
            var repositorio = new RepositorioGrupos(new MongoClient(leitorConfiguracoes.StringConexao), leitorConfiguracoes);

            Grupo grupo = null;

            try
            {
                grupo = new ConstrutorGrupo().Construir();
                repositorio.Inserir(grupo);

                var grupoRecuperado = repositorio.ListarPorId(grupo.Id);

                var todosOsGrupos = repositorio.ListarTodos();

                grupoRecuperado.Id.Should().Be(grupo.Id);
                grupoRecuperado.Nome.Should().BeEquivalentTo(grupo.Nome);
                todosOsGrupos.Should().NotBeNullOrEmpty();
            }
            finally
            {
                if (grupo != null)
                    repositorio.Remover(grupo.Id);
            }
        }
    }
}