using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaManutencaoDto
    {
        public virtual IEnumerable<ManutencaoDto> Criar(IEnumerable<Manutencao> manutencoes)
        {
            return manutencoes.Select(Criar);
        }

        public virtual ManutencaoDto Criar(Manutencao manutencao)
        {
            return new ManutencaoDto {Id = manutencao.Id, Data = manutencao.Data, Parte = manutencao.Parte};
        }
    }
}