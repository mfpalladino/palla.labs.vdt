using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class ParametrosVencimentoCentralAlarme : ParametrosVencimento
    {
        public override bool ControladoPelaDataDeManutencaoDasPartes
        {
            get { return false; }
        }

        public override IEnumerable<ParteEquipamento> Partes
        {
            get
            {
                return new List<ParteEquipamento>
                {
                    new ParteEquipamento("CentralAlarme", 1 /*Não é controlado pela data*/)
                };
            }
        }
    }
}