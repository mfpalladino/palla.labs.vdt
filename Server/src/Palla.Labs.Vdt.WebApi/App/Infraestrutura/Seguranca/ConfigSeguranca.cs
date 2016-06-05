using System.Configuration;

namespace Palla.Labs.Vdt.App.Infraestrutura.Seguranca
{
    public class ConfigSeguranca
    {
        public string AlgoritmoParaCriptografia
        {
            get { return ConfigurationManager.AppSettings["alg-para-criotografia"]; }
        }

        public string SaltParaCriptografia
        {
            get { return ConfigurationManager.AppSettings["salt-para-criotografia"]; }
        }
    }
}