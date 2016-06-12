using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaGrupo
    {
        public virtual Grupo Criar(Guid siteId, GrupoDto grupoDto)
        {
            return Criar(siteId, grupoDto.Id, grupoDto);
        }

        public virtual Grupo Criar(Guid siteId, Guid id, GrupoDto grupoDto)
        {
            return new Grupo(siteId, id, grupoDto.Nome);
        }
    }
}