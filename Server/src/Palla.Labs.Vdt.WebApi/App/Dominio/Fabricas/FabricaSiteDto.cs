using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaSiteDto
    {
        public virtual IEnumerable<SiteDto> Criar(IEnumerable<Site> sites)
        {
            return sites.Select(Criar).OrderBy(x => x.Nome);
        }

        public virtual SiteDto Criar(Site site)
        {
            return new SiteDto {Id = site.Id, Nome = site.Nome, Email = site.Email};
        }
    }
}