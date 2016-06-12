using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

namespace Palla.Labs.Vdt.Controllers
{
    public class VerificaSaudeController : ApiController
    {
        private readonly RepositorioEquipamentos _repositorioEquipamentos;

        public VerificaSaudeController(RepositorioEquipamentos repositorioEquipamentos)
        {
            _repositorioEquipamentos = repositorioEquipamentos;
        }

        public HttpResponseMessage Get()
        {
            _repositorioEquipamentos.BuscarPorId(Guid.NewGuid(), Guid.NewGuid()); //Verifica se consigo chegar no banco de dados
            return Request.CreateResponse(HttpStatusCode.OK, "Aparentemente está tudo ok...");
        }
    }
}