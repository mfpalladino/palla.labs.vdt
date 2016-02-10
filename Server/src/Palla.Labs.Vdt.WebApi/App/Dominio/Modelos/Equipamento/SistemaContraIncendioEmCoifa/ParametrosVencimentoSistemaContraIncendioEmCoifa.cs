using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class ParametrosVencimentoSistemaContraIncendioEmCoifa : ParametrosVencimento
    {
        public override IEnumerable<ParteEquipamento> Partes
        {
            get
            {
                return new List<ParteEquipamento>
                {
                    new ParteEquipamento("CO2", 12),
                    new ParteEquipamento("Saponificante", 60),
                };
            }
        }
    }
}