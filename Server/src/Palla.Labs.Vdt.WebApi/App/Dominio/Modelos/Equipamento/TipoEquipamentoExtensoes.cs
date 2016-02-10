using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public static class TipoEquipamentoExtensoes
    {
        public static string PegaNome(this TipoEquipamento source)
        {
            if (source == TipoEquipamento.Extintor)
                return "Extintor";
            if (source == TipoEquipamento.Mangueira)
                return "Mangueira";
            if (source == TipoEquipamento.CentralAlarme)
                return "Central de alarme";
            if (source == TipoEquipamento.SistemaContraIncendioEmCoifa)
                return "Sistema contra inc�ndio";

            throw new Exception("Tipo n�o mapeado para o nome");
        }
    }
}