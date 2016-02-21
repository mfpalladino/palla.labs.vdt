using FluentAssertions;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Unidade.Modelos
{
    [TestFixture]
    public class CnpjDeve
    {
        [Test]
        public void SepararApenasOsNumerosDoCnpjInformado()
        {
            //Arrange
            const string cnpjLiteral = "77.046.700/0001-41";
            const string cnpjLiteralSomenteNumeros = "77046700000141";
            
            //action
            var cnpj = new Cnpj(cnpjLiteral);

            //Asserts
            cnpj.Numero.Should().Be(cnpjLiteralSomenteNumeros);
        }
    }
}