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
    public class UsuariosController : ApiController
    {
        private readonly CriadorUsuario _criadorUsuario;
        private readonly ModificadorUsuario _modificadorUsuario;
        private readonly LocalizadorUsuario _localizadorUsuario;

        public UsuariosController(CriadorUsuario criadorUsuario, 
            ModificadorUsuario modificadorUsuario, 
            LocalizadorUsuario localizadorUsuario)
        {
            _criadorUsuario = criadorUsuario;
            _modificadorUsuario = modificadorUsuario;
            _localizadorUsuario = localizadorUsuario;
        }

        [HttpPost]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Post([FromBody] UsuarioDto usuarioDto)
        {
            var usuarioSalvo = _criadorUsuario.Criar(Request.PegarSiteIdDoUsuario(), usuarioDto);
            var response = Request.CreateResponse(HttpStatusCode.Created, usuarioSalvo);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = usuarioSalvo.Id }));
            return response;
        }

        [HttpPut]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        [Route("usuarios/{id}")]
        public HttpResponseMessage Put([FromUri] string id, [FromBody] UsuarioDto usuarioDto)
        {
            _modificadorUsuario.Modificar(Request.PegarSiteIdDoUsuario(), id, usuarioDto);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        [Route("usuarios/{id}")]
        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorUsuario.Localizar(Request.PegarSiteIdDoUsuario(), id));
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorUsuario.Localizar(Request.PegarSiteIdDoUsuario()));
        }
    }
}