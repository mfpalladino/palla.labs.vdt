using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorCentralAlarme
    {
        private Guid _siteId;

        public ConstrutorCentralAlarme NoSite(Guid siteId)
        {
            _siteId = siteId;
            return this;
        }

        public CentralAlarme Construir()
        {
            return new CentralAlarme(_siteId, Guid.NewGuid(), "fabricante", "modelo", TipoCentralAlarme.Analogico, 2, true, 2, 2, new List<Manutencao>(), true);
        }
    }
}