using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public abstract class ParametrosManutencao
    {
        public virtual bool ControladaPelasPartes
        {
            get { return true; }
        }

        public abstract IEnumerable<ParteEquipamento> Partes { get; }
    }
}