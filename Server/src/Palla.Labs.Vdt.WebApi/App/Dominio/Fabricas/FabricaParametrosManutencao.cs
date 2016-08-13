using System;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public static class FabricaParametrosManutencao
    {
        public static ParametrosManutencao Criar(Equipamento equipamento)
        {
            if (equipamento.Tipo == TipoEquipamento.Extintor)
                return new ParametrosManutencaoExtintor(((Extintor)equipamento).FabricadoEm);
            if (equipamento.Tipo == TipoEquipamento.Mangueira)
                return new ParametrosManutencaoMangueira();
            if (equipamento.Tipo == TipoEquipamento.CentralAlarme)
                return new ParametrosManutencaoCentralAlarme();
            if (equipamento.Tipo == TipoEquipamento.SistemaContraIncendioEmCoifa)
                return new ParametrosManutencaoSistemaContraIncendioEmCoifa();

            throw new Exception("Não existe parâmetros para o tipo especificado");
        }
    }
}