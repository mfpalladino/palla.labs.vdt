using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaGrupoDto
    {
        public virtual IEnumerable<GrupoDto> Criar(IEnumerable<Grupo> grupos)
        {
            return grupos.Select(Criar);
        }

        public virtual GrupoDto Criar(Grupo grupo)
        {
            return new GrupoDto {Id = grupo.Id, Nome = grupo.Nome};
        }
    }
}