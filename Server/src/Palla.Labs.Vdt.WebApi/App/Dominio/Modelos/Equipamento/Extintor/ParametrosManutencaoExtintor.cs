using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class ParametrosManutencaoExtintor : ParametrosManutencao
    {
        public override IEnumerable<ParteEquipamento> Partes
        {
            get
            {
                return new List<ParteEquipamento>
                {
                    new ParteEquipamento(ParteEquipamento.EXTINTOR, 12)
                };
            }
        }
    }
}