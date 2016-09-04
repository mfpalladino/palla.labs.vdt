using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class ParametrosManutencaoSistemaContraIncendioEmCoifa : ParametrosManutencao
    {
        public override IEnumerable<ParteEquipamento> Partes
        {
            get
            {
                return new List<ParteEquipamento>
                {
                    new ParteEquipamento(ParteEquipamento.Co2, 12),
                    new ParteEquipamento(ParteEquipamento.Saponificante, 60),
                };
            }
        }
    }
}