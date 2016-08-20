using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorSistemaContraIncendioEmCoifa
    {
        private Guid _siteId;

        public ConstrutorSistemaContraIncendioEmCoifa NoSite(Guid siteId)
        {
            _siteId = siteId;
            return this;
        }

        public SistemaContraIncendioEmCoifa Construir()
        {
            return new SistemaContraIncendioEmCoifa(_siteId, Guid.NewGuid(), "central", 2, 2, 2, new List<Manutencao>(), true);
        }
    }
}