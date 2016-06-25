using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Web
{
    public class AtributoValidadorDePerfil : AuthorizeAttribute
    {
        private readonly TipoUsuario _tipoUsuario;

        public AtributoValidadorDePerfil(TipoUsuario tipoUsuario)
        {
            _tipoUsuario = tipoUsuario;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Autorizar(actionContext))
                return;

            HandleUnauthorizedRequest(actionContext);
        }

        private bool Autorizar(HttpActionContext actionContext)
        {
            try
            {
                var request = actionContext.Request;
                var usuario = request.PegarUsuario();

                if (usuario.TipoUsuario == TipoUsuario.Dono)
                    return true;

                if (usuario.TipoUsuario == TipoUsuario.Manutenedor)
                    return _tipoUsuario == TipoUsuario.Manutenedor || _tipoUsuario == TipoUsuario.Consumidor;
                
                if (usuario.TipoUsuario == TipoUsuario.Consumidor)
                    return _tipoUsuario == TipoUsuario.Consumidor;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}