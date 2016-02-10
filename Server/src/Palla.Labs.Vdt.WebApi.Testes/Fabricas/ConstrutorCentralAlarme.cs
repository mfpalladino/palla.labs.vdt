using System.Collections.Generic;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorCentralAlarme
    {
        public CentralAlarme Construir()
        {
            return new CentralAlarme("fabricante", "modelo", TipoCentralAlarme.Analogico, 2, true, 2, 2, new List<Manutencao>());
        }
    }
}