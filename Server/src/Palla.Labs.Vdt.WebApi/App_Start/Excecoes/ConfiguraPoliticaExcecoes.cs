using System.Web.Http;

namespace Palla.Labs.Vdt.Excecoes
{
    public class ConfiguraPoliticaExcecoes
    {
        public static void Configurar(HttpConfiguration config)
        {
            GlobalConfiguration.Configuration.Filters.Add(new FiltroExcecoes());
        }
    }
}