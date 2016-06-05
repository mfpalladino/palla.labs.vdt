using System.Net;
using System.Net.Http;
using System.Web;

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
    }
}