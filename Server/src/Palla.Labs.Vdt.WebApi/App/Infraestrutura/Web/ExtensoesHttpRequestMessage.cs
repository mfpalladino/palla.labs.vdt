using System;
using System.Net;
using System.Net.Http;
using System.Web;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Web
{
    public static class ExtensoesHttpRequestMessage
    {
        public static string PegarIpDoUsuario(this HttpRequestMessage request)
        {
            return request.Properties.ContainsKey("MS_HttpContext") ? 
                IPAddress.Parse(((HttpContextBase)request.Properties["MS_HttpContext"]).Request.UserHostAddress).ToString() : null;
        }

        public static string PegarUserAgentDoUsuario(this HttpRequestMessage request)
        {
            return request.Headers.UserAgent.ToString();
        }

        public static Guid PegarSiteIdDoUsuario(this HttpRequestMessage request)
        {
            return new Guid(request.Properties["SiteId"].ToString());
        }

        public static Usuario PegarUsuario(this HttpRequestMessage request)
        {
            return request.Properties["Usuario"] as Usuario;
        }

        public static void SetarSiteIdDoUsuario(this HttpRequestMessage request, Guid siteId)
        {
            request.Properties.Add("SiteId", siteId);
        }

        public static void SetarUsuario(this HttpRequestMessage request, Usuario usuario)
        {
            request.Properties.Add("Usuario", usuario);
        }                    
    }
}