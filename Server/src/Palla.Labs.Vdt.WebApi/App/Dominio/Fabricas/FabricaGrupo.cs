using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaGrupo
    {
        public virtual Grupo Criar(GrupoDto grupoDto)
        {
            return Criar(grupoDto.Id, grupoDto);
        }

        public virtual Grupo Criar(Guid id, GrupoDto grupoDto)
        {
            return new Grupo(id, grupoDto.Nome);
        }
    }
}