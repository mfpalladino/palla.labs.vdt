using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Web;
using Palla.Labs.Vdt.App.ServicosAplicacao;

namespace Palla.Labs.Vdt.Controllers
{
    [AtributoValidadorDeToken]
    public class GruposController : ApiController
    {
        private readonly CriadorGrupo _criadorGrupo;
        private readonly ModificadorGrupo _modificadorGrupo;
        private readonly LocalizadorGrupo _localizadorGrupo;
        private readonly LocalizadorEquipamento _localizadorEquipamento;

        public GruposController(CriadorGrupo criadorGrupo, 
            ModificadorGrupo modificadorGrupo, 
            LocalizadorGrupo localizadorGrupo, 
            LocalizadorEquipamento localizadorEquipamento)
        {
            _criadorGrupo = criadorGrupo;
            _modificadorGrupo = modificadorGrupo;
            _localizadorGrupo = localizadorGrupo;
            _localizadorEquipamento = localizadorEquipamento;
        }

        [HttpPost]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Post([FromBody] GrupoDto grupoDto)
        {
            var grupoSalvo = _criadorGrupo.Criar(Request.PegarSiteIdDoUsuario(), grupoDto);
            var response = Request.CreateResponse(HttpStatusCode.Created, grupoSalvo);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = grupoSalvo.Id }));
            return response;
        }

        [HttpPut]
        [Route("grupos/{id}")]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Put([FromUri] string id, [FromBody] GrupoDto grupoDto)
        {
            _modificadorGrupo.Modificar(Request.PegarSiteIdDoUsuario(), id, grupoDto);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [HttpGet]
        [Route("grupos/{id}")]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorGrupo.Localizar(Request.PegarSiteIdDoUsuario(), id));
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Consumidor)]
        public HttpResponseMessage Get()
        {
            var usuario = Request.PegarUsuario();

            return Request.CreateResponse(HttpStatusCode.OK,
                _localizadorGrupo.Localizar(
                    Request.PegarSiteIdDoUsuario(),
                    usuario.TipoUsuario == TipoUsuario.Consumidor ? usuario.Grupos : null));
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Consumidor)]
        [Route("grupos/{id}/sumariosituacao")]
        public HttpResponseMessage SumarioSituacao(string id)
        {
            var equipamentosDoGrupo = _localizadorEquipamento.LocalizarPorGrupo(Request.PegarSiteIdDoUsuario(), id, SituacaoManutencao.Todos);
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorGrupo.SumarioSituacao(equipamentosDoGrupo));
        }
    }
}