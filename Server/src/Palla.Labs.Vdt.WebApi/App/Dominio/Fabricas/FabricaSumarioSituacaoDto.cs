using System;
using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaSumarioSituacaoDto
    {
        public virtual SumarioSituacaoDto Criar(IEnumerable<EquipamentoDto> equipamentos)
        {
            var listaEquipamentos = equipamentos.ToList();
            var total = listaEquipamentos.Count();
            var ok = listaEquipamentos.Count(x => x.SituacaoManutencao == (int)SituacaoManutencao.Ok);
            var atencao = listaEquipamentos.Count(x => x.SituacaoManutencao == (int)SituacaoManutencao.EstadoDeAtencao);
            var critico = listaEquipamentos.Count(x => x.SituacaoManutencao == (int)SituacaoManutencao.EstadoCritico);
            var inconclusivo = listaEquipamentos.Count(x => x.SituacaoManutencao == (int)SituacaoManutencao.Inconclusivo);

            return new SumarioSituacaoDto
            {
                PercentualOk = CalculaPercentual(total, ok),
                PercentualAtencao = CalculaPercentual(total, atencao),
                PercentualCritico = CalculaPercentual(total, critico),
                PercentualInconclusivo = CalculaPercentual(total, inconclusivo)
            };
        }

        private static int CalculaPercentual(int total, int valor)
        {
            return total > 0 ? Convert.ToInt32(((float)valor / (float)total) * 100) : 0;
        }
    }
}