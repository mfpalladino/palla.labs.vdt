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
                cliente = new ConstrutorCliente().Construir();
                repositorio.Inserir(cliente);

                var clienteRecuperado = repositorio.BuscarPorId(Guid.NewGuid(), cliente.Id);

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