using System;

namespace Palla.Labs.Vdt.App.Dominio.Modelos.Equipamento
{
    public abstract class EquipamentoBase
    {
        private readonly Guid _id;
        private readonly TipoEquipamento _tipo;

        protected EquipamentoBase(Guid id, TipoEquipamento tipo = TipoEquipamento.Extintor)
        {
            _id = id;
            _tipo = tipo;
        }

        public Guid Id
        {
            get { return _id; }
        }

        public TipoEquipamento Tipo
        {
            get { return _tipo; }
        }
    }
}