using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorMangueira
    {
        private Guid _siteId;

        public ConstrutorMangueira NoSite(Guid siteId)
        {
            _siteId = siteId;
            return this;
        }

        public Mangueira Construir()
        {
            return new Mangueira(_siteId, Guid.NewGuid(), TipoMangueira.Tipo1, DiametroMangueira.DoisMetrosEMeio, ComprimentoMangueira.TrintaMetros, new List<Manutencao>(), true);
        }
    }
}