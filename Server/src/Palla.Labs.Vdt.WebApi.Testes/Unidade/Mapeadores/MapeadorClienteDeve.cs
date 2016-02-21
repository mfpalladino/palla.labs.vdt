using FluentAssertions;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.AutoMapper;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;
using Palla.Labs.Vdt.WebApi.Testes.Fabricas;

namespace Palla.Labs.Vdt.WebApi.Testes.Unidade.Mapeadores
{
    [TestFixture]
    public class MapeadorClienteDeve //usado apenas para aprender sobre o automapper. Pouco valor...
    {
        [Test]
        public void ConseguirGerarCorretamenteUmDtoComBaseNaEntidade() 
        {
            //Arrange
            var cliente = new ConstrutorCliente().Construir();

            //Act
            var clienteDto = ConfiguraAutoMapper.Mapeador.Map<ClienteDto>(cliente);

            //Asserts
            clienteDto.EnderecoLogradouro.Should().Be(cliente.Endereco.Logradouro);
            clienteDto.EnderecoCep.Should().Be(cliente.Endereco.Cep);
            clienteDto.CorreioEletronicoLoja.Should().Be(cliente.CorreioEletronicoLoja.Endereco);
            clienteDto.Cnpj.Should().Be(cliente.Cnpj.Numero);
        }

        [Test]
        public void ConseguirGerarCorretamenteUmaEntidadeComBaseNoDto()
        {
            //Arrange
            var clienteOriginal = new ConstrutorCliente().Construir();
            var clienteDto = ConfiguraAutoMapper.Mapeador.Map<ClienteDto>(clienteOriginal);

            //Act
            var clienteGerado = ConfiguraAutoMapper.Mapeador.Map<Cliente>(clienteDto);
            
            //Asserts
            clienteDto.EnderecoLogradouro.Should().Be(clienteGerado.Endereco.Logradouro);
            clienteDto.EnderecoCep.Should().Be(clienteGerado.Endereco.Cep);
            clienteDto.CorreioEletronicoLoja.Should().Be(clienteGerado.CorreioEletronicoLoja.Endereco);
            clienteDto.Cnpj.Should().Be(clienteGerado.Cnpj.Numero);
        }
    }
}
