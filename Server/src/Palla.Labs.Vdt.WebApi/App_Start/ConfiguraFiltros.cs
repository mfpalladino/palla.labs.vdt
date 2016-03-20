using System.Web.Mvc;

namespace Palla.Labs.Vdt
{
    public class ConfiguraFiltros
    {
        public static void Configurar(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
