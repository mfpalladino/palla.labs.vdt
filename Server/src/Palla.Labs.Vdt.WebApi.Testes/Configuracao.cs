using NUnit.Framework;
using Palla.Labs.Vdt.App.Infraestrutura.AutoMapper;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

namespace Palla.Labs.Vdt.WebApi.Testes
{
    [SetUpFixture]
    public class Configuracao
    {
        [OneTimeSetUp]
        public void RodarAntesDosTestes()
        {
            ConfiguraMongo.Configurar();
            ConfiguraAutoMapper.Configurar();
        }
    }
}