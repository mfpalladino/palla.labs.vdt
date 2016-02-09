using System.Web.Http;

namespace Palla.Labs.Vdt.ExceptionsPolicy
{
    public class ExceptionsPolicyConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            GlobalConfiguration.Configuration.Filters.Add(new DomainExceptionToHttpStatusCodeFilter());
        }
    }
}