using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Palla.Labs.Vdt.App.Dominio.Fabricas;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public abstract class Equipamento
    {
        private readonly Guid _id;
        private readonly TipoEquipamento _tipo;
        private ParametrosVencimento _parametrosVencimento;
        private readonly IList<Manutencao> _manutencoes;

        protected Equipamento(Guid id, IList<Manutencao> manutencoes, TipoEquipamento tipo)
        {
            _id = id;
            _manutencoes = manutencoes;
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

        public IReadOnlyList<Manutencao> Manutencoes
        {
            get { return new ReadOnlyCollection<Manutencao>(_manutencoes); }
        }

        public ParametrosVencimento ParametrosVencimento
        {
            get
            {
                return _parametrosVencimento ??
                       (_parametrosVencimento = FabricaParametrosVencimento.Criar(_tipo));
            }
        }
    }
}