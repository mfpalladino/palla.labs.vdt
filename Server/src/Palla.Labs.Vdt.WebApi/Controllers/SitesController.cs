using System.Net;
using System.Net.Http;
using System.Web.Http;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Web;
using Palla.Labs.Vdt.App.ServicosAplicacao;

namespace Palla.Labs.Vdt.Controllers
{
    [AtributoValidadorDeToken]
    public class SitesController : ApiController
    {
        private readonly LocalizadorSite _localizadorSite;

        public SitesController(
            LocalizadorSite localizadorSite)
        {
            _localizadorSite = localizadorSite;
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorSite.Localizar(Request.PegarSiteIdDoUsuario()));
        }
    }
}