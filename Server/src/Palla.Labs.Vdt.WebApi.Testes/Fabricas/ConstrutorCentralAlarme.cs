using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorCentralAlarme
    {
        public CentralAlarme Construir()
        {
            return new CentralAlarme(Guid.NewGuid(), Guid.NewGuid(), "fabricante", "modelo", TipoCentralAlarme.Analogico, 2, true, 2, 2, new List<Manutencao>());
        }
    }
}