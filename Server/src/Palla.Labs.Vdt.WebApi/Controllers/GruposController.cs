using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.ServicosAplicacao;

namespace Palla.Labs.Vdt.Controllers
{
    public class GruposController : ApiController
    {
        private readonly CriadorGrupo _criadorGrupo;
        private readonly ModificadorGrupo _modificadorGrupo;
        private readonly LocalizadorGrupo _localizadorGrupo;

        public GruposController(CriadorGrupo criadorGrupo, ModificadorGrupo modificadorGrupo, LocalizadorGrupo localizadorGrupo)
        {
            _criadorGrupo = criadorGrupo;
            _modificadorGrupo = modificadorGrupo;
            _localizadorGrupo = localizadorGrupo;
        }

        [HttpPost]
        [AllowCrossSiteJsonAttribute]
        public HttpResponseMessage Post([FromBody] GrupoDto grupoDto)
        {
            var grupoSalvo = _criadorGrupo.Criar(grupoDto);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = grupoSalvo.Id }));
            return response;
        }

        [HttpPut]
        [AllowCrossSiteJsonAttribute]
        [Route("grupos/{id}")]
        public HttpResponseMessage Put([FromUri] string id, [FromBody] GrupoDto grupoDto)
        {
            _modificadorGrupo.Modificar(id, grupoDto);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [HttpGet]
        [AllowCrossSiteJsonAttribute]
        [Route("grupos/{id}")]
        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorGrupo.Localizar(id));
        }

        [HttpGet]
        [AllowCrossSiteJsonAttribute]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorGrupo.Localizar());
        }
    }
}