using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Palla.Labs.Vdt.Controllers
{
    public class HealthCheckController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<string>(HttpStatusCode.OK, "Aparentemente está tudo ok (testando appveyor)...");
        }
    }
}