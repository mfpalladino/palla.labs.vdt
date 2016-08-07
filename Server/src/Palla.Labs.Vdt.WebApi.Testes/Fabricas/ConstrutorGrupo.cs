using System;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorGrupo
    {
        private Guid _siteId;

        public ConstrutorGrupo NoSite(Guid siteId)
        {
            _siteId = siteId;
            return this;
        }

        public Grupo Construir()
        {
            return new Grupo(_siteId, "grupo");
        }
    }
}