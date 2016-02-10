using NUnit.Framework;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

namespace Palla.Labs.Vdt.WebApi.Testes.Integracao
{
    [SetUpFixture]
    public class Configuracao
    {
        [OneTimeSetUp]
        public void RodarAntes()
        {
            Registrador.EfetuarRegistros();
        }
    }
}