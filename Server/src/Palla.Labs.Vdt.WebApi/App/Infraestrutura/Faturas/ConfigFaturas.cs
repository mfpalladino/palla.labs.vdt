using System;
using System.Configuration;

namespace Palla.Labs.Vdt.App.Infraestrutura.Faturas
{
    public class ConfigFaturas
    {
        public decimal ValorPorEquipamento
        {
            get { return Convert.ToDecimal(ConfigurationManager.AppSettings["valor-equipamento"]); }
        }

        public decimal ValorPorUsuario
        {
            get { return Convert.ToDecimal(ConfigurationManager.AppSettings["valor-usuario"]); }
        }
    }
}