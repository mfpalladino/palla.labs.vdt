using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Web;
using Palla.Labs.Vdt.App.ServicosAplicacao;

namespace Palla.Labs.Vdt.Controllers
{
    [AtributoValidadorDeToken]
    [AtributoValidadorDePerfil(TipoUsuario.Manutenedor)]
    public class EquipamentosController : ApiController
    {
        private readonly CriadorEquipamento _criadorEquipamento;
        private readonly ModificadorEquipamento _modificadorEquipamento;
        private readonly LocalizadorEquipamento _localizadorEquipamento;
        private readonly CriadorManutencao _criadorManutencao;

        public EquipamentosController(CriadorEquipamento criadorEquipamento, ModificadorEquipamento modificadorEquipamento, 
            LocalizadorEquipamento localizadorEquipamento, CriadorManutencao criadorManutencao)
        {
            _criadorEquipamento = criadorEquipamento;
            _modificadorEquipamento = modificadorEquipamento;
            _localizadorEquipamento = localizadorEquipamento;
            _criadorManutencao = criadorManutencao;
        }

        [HttpPost]
        public HttpResponseMessage Post([ModelBinder] EquipamentoDto equipamentoDto)
        {
            var equipamentoSalvo = _criadorEquipamento.Criar(Request.PegarSiteIdDoUsuario(), equipamentoDto);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = equipamentoSalvo.Id }));
            return response;
        }

        [HttpPut]
        [Route("equipamentos/{id}")]
        public HttpResponseMessage Put([FromUri] string id, [ModelBinder] EquipamentoDto equipamentoDto)
        {
            _modificadorEquipamento.Modificar(Request.PegarSiteIdDoUsuario(), id, equipamentoDto);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [HttpGet]
        [Route("equipamentos/{id}")]
        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorEquipamento.Localizar(Request.PegarSiteIdDoUsuario(), id, null));
        }

        [HttpGet]
        [Route("equipamentos/{id}")]
        public HttpResponseMessage Get(string id, long referenciaSituacao)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorEquipamento.Localizar(Request.PegarSiteIdDoUsuario(), id, referenciaSituacao));
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorEquipamento.Localizar(Request.PegarSiteIdDoUsuario(), null));
        }

        [HttpGet]
        public HttpResponseMessage Get(long referenciaSituacao)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorEquipamento.Localizar(Request.PegarSiteIdDoUsuario(), referenciaSituacao));
        }

        [HttpGet]
        public HttpResponseMessage Get(Guid clienteId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorEquipamento.LocalizarPorCliente(Request.PegarSiteIdDoUsuario(), clienteId.ToString()));
        }

        [HttpPost]
        [Route("equipamentos/{id}/manutencoes")]
        public HttpResponseMessage Post([FromUri] string id, [FromBody] ManutencaoDto manutencaoDto)
        {
            _criadorManutencao.Criar(Request.PegarSiteIdDoUsuario(), id, manutencaoDto);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            return response;
        }

        [HttpGet]
        [Route("equipamentos/{id}/manutencoes")]
        public HttpResponseMessage GetManutencoes(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorEquipamento.LocalizarManutencoes(Request.PegarSiteIdDoUsuario(), id));
        }
    }
}