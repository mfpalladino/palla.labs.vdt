using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.ServicosAplicacao;

namespace Palla.Labs.Vdt.Controllers
{
    public class EquipamentosController : ApiController
    {
        private readonly CriadorEquipamento _criadorEquipamento;
        private readonly LocalizadorEquipamento _localizadorEquipamento;

        public EquipamentosController(CriadorEquipamento criadorEquipamento, LocalizadorEquipamento localizadorEquipamento)
        {
            _criadorEquipamento = criadorEquipamento;
            _localizadorEquipamento = localizadorEquipamento;
        }

        [HttpPost]
        public HttpResponseMessage Post([ModelBinder] EquipamentoDto equipamentoDto)
        {
            var equipamentoSalvo = _criadorEquipamento.Criar(equipamentoDto);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = equipamentoSalvo.Id }));
            return response;
        }

        [HttpGet]
        [Route("equipamentos/{id}")]
        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorEquipamento.Localizar(id));
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorEquipamento.Localizar());
        }

    }
}