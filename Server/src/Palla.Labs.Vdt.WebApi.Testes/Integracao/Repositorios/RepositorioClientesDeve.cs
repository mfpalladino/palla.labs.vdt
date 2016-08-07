using System;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.WebApi.Testes.Fabricas;

namespace Palla.Labs.Vdt.WebApi.Testes.Integracao.Repositorios
{
    [TestFixture]
    public class RepositorioClientesDeve
    {
        [Test]
        public void FazerOBasicoCorretamente()
        {
            var leitorConfiguracoes = new ConfigBancoDadosVariavelAmbienteTestes();
            var repositorio = new RepositorioClientes(new MongoClient(leitorConfiguracoes.StringConexao), leitorConfiguracoes);

            Cliente cliente = null;

            try
            {
                var siteId = Guid.NewGuid();
                cliente = new ConstrutorCliente().NoSite(siteId).Construir();
                repositorio.Inserir(cliente);

                var clienteRecuperado = repositorio.BuscarPorId(siteId, cliente.Id);

                clienteRecuperado.Id.Should().Be(cliente.Id);
                clienteRecuperado.Nome.Should().BeEquivalentTo(cliente.Nome);
            }
            finally
            {
                if (cliente != null)
                    repositorio.Remover(cliente.Id);
            }
        }
    }
}