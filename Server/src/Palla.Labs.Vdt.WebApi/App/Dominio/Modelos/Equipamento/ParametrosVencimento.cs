using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public abstract class ParametrosVencimento
    {
        public virtual bool ControladoPelaDataDeManutencaoDasPartes
        {
            get { return true; }
        }

        public abstract IEnumerable<ParteEquipamento> Partes { get; }
    }
}