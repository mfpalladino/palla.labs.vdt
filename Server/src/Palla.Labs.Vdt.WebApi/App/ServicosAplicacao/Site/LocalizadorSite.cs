using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class LocalizadorSite
    {
        private readonly RepositorioSites _repositorioSites;
        private readonly FabricaSiteDto _fabricaSiteDto;

        public LocalizadorSite(RepositorioSites repositorioSites, FabricaSiteDto fabricaSiteDto)
        {
            _repositorioSites = repositorioSites;
            _fabricaSiteDto = fabricaSiteDto;
        }

        public SiteDto Localizar(Guid siteId)
        {
            return _fabricaSiteDto.Criar(_repositorioSites.BuscarPorId(siteId));
        }
    }
}