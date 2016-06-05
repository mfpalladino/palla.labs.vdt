using System.Net;
using System.Net.Http;
using System.Web.Http;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Infraestrutura.Web;
using Palla.Labs.Vdt.App.ServicosAplicacao;

namespace Palla.Labs.Vdt.Controllers
{
    public class LoginController : ApiController
    {
        private readonly Login _login;

        public LoginController(Login login)
        {
            _login = login;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] LoginDto login)
        {
            var token = _login.Logar(login, Request.PegarIpDoUsuario(), Request.PegarUserAgentDoUsuario());
            var response = Request.CreateResponse(HttpStatusCode.OK, new {token, usuario = login.Usuario});
            return response;
        }
    }
}