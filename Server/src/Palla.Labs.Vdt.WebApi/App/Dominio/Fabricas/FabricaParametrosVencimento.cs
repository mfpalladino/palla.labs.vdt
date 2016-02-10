using System;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public static class FabricaParametrosVencimento
    {
        public static ParametrosVencimento Criar(TipoEquipamento tipoEquipamento)
        {
            if (tipoEquipamento == TipoEquipamento.Extintor)
                return new ParametrosVencimentoExtintor();
            if (tipoEquipamento == TipoEquipamento.Mangueira)
                return new ParametrosVencimentoMangueira();
            if (tipoEquipamento == TipoEquipamento.CentralAlarme)
                return new ParametrosVencimentoCentralAlarme();
            if (tipoEquipamento == TipoEquipamento.SistemaContraIncendioEmCoifa)
                return new ParametrosVencimentoSistemaContraIncendioEmCoifa();

            throw new Exception("Não existe parâmetros para o tipo especificado");
        }
    }
}