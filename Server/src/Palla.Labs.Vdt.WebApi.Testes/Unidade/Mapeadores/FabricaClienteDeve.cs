using FluentAssertions;
using Moq;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.WebApi.Testes.Fabricas;

namespace Palla.Labs.Vdt.WebApi.Testes.Unidade.Mapeadores
{
    [TestFixture]
    public class FabricaClienteDeve
    {
        [Test]
        public void ConseguirGerarCorretamenteUmDtoComBaseNaEntidade() 
        {
            //Arrange
            var cliente = new ConstrutorCliente().Construir();

            //Act
            var clienteDto = new FabricaClienteDto(new Mock<RepositorioGrupos>().Object).Criar(cliente);

            //Asserts
            clienteDto.Logradouro.Should().Be(cliente.Endereco.Logradouro);
            clienteDto.Cep.Should().Be(cliente.Endereco.Cep);
            clienteDto.CorreioEletronicoLoja.Should().Be(cliente.CorreioEletronicoLoja.Endereco);
            clienteDto.Cnpj.Should().Be(cliente.Cnpj.Numero);
        }

        [Test]
        public void ConseguirGerarCorretamenteUmaEntidadeComBaseNoDto()
        {
            //Arrange
            var clienteOriginal = new ConstrutorCliente().Construir();
            var clienteDto = new FabricaClienteDto(new Mock<RepositorioGrupos>().Object).Criar(clienteOriginal);

            //Act
            var clienteGerado = new FabricaCliente().Criar(clienteDto);
            
            //Asserts
            clienteDto.Logradouro.Should().Be(clienteGerado.Endereco.Logradouro);
            clienteDto.Cep.Should().Be(clienteGerado.Endereco.Cep);
            clienteDto.CorreioEletronicoLoja.Should().Be(clienteGerado.CorreioEletronicoLoja.Endereco);
            clienteDto.Cnpj.Should().Be(clienteGerado.Cnpj.Numero);
        }
    }
}
