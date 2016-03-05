using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaManutencao
    {
        public virtual Manutencao Criar(ManutencaoDto manutencaoDto)
        {
            return Criar(manutencaoDto.Id, manutencaoDto);
        }

        public virtual Manutencao Criar(Guid id, ManutencaoDto manutencaoDto)
        {
            return new Manutencao(id, manutencaoDto.Data, manutencaoDto.Parte);
        }
    }
}