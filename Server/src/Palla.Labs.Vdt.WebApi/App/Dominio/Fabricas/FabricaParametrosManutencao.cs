using System;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public static class FabricaParametrosManutencao
    {
        public static ParametrosManutencao Criar(TipoEquipamento tipoEquipamento)
        {
            if (tipoEquipamento == TipoEquipamento.Extintor)
                return new ParametrosManutencaoExtintor();
            if (tipoEquipamento == TipoEquipamento.Mangueira)
                return new ParametrosManutencaoMangueira();
            if (tipoEquipamento == TipoEquipamento.CentralAlarme)
                return new ParametrosManutencaoCentralAlarme();
            if (tipoEquipamento == TipoEquipamento.SistemaContraIncendioEmCoifa)
                return new ParametrosManutencaoSistemaContraIncendioEmCoifa();

            throw new Exception("Não existe parâmetros para o tipo especificado");
        }
    }
}