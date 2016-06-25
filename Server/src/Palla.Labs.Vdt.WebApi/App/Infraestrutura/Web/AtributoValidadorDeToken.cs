using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Seguranca;
using Palla.Labs.Vdt.App.Infraestrutura.SimpleInjector;

namespace Palla.Labs.Vdt.App.Infraestrutura.Web
{
    public class AtributoValidadorDeToken : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Autorizar(actionContext))
                return;

            HandleUnauthorizedRequest(actionContext);
        }

        private static bool Autorizar(HttpActionContext actionContext)
        {
            try
            {
                var request = actionContext.Request;
                var token = request.Headers.Authorization.ToString().Split(' ')[1];
                var ip = request.PegarIpDoUsuario();
                var userAgent = request.PegarUserAgentDoUsuario();

                var validadorDeToken = BuscadorDeInstancias.BuscarEstatico<ValidadorDeToken>();
                Guid siteId;
                Usuario usuario;
                if (validadorDeToken.Validar(token, ip, userAgent, out siteId, out usuario))
                {
                    request.SetarSiteIdDoUsuario(siteId);
                    request.SetarUsuario(usuario);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}