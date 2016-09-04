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
    public class FaturasController : ApiController
    {
        private readonly CriadorFatura _criadorFatura;
        private readonly LocalizadorFatura _localizadorFatura;

        public FaturasController(CriadorFatura criadorFatura, LocalizadorFatura localizadorFatura)
        {
            _criadorFatura = criadorFatura;
            _localizadorFatura = localizadorFatura;
        }

        [HttpPost]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Post([FromBody] FaturaDto faturaDto)
        {
            var faturaSalva = _criadorFatura.Criar(Request.PegarSiteIdDoUsuario(), faturaDto);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = faturaSalva.Id }));
            return response;
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        [Route("faturas/{id}")]
        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorFatura.Localizar(Request.PegarSiteIdDoUsuario(), id));
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorFatura.Localizar(Request.PegarSiteIdDoUsuario()));
        }

    }
}