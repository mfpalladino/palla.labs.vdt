using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Palla.Labs.Vdt.App.Dominio.Fabricas;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public abstract class Equipamento : EntidadeBase<Guid>
    {
        private readonly Guid _siteId;
        private readonly Guid _clienteId;
        private readonly TipoEquipamento _tipo;
        private readonly bool _estaAtivo;
        private ParametrosManutencao _parametrosManutencao;
        private readonly IList<Manutencao> _manutencoes;

        protected Equipamento(Guid siteId, Guid id, Guid clienteId, IList<Manutencao> manutencoes, TipoEquipamento tipo, bool estaAtivo) : base(id)
        {
            _siteId = siteId;
            _clienteId = clienteId;
            _manutencoes = manutencoes;
            _tipo = tipo;
            _estaAtivo = estaAtivo;
        }

        public Guid SiteId
        {
            get { return _siteId; }
        }

        public Guid ClienteId
        {
            get { return _clienteId; }
        }

        public TipoEquipamento Tipo
        {
            get { return _tipo; }
        }

        public bool EstaAtivo
        {
            get { return _estaAtivo; }
        }

        public abstract string Nome { get; }

        public IReadOnlyList<Manutencao> Manutencoes
        {
            get { return new ReadOnlyCollection<Manutencao>(_manutencoes); }
        }

        public ParametrosManutencao ParametrosManutencao
        {
            get
            {
                return _parametrosManutencao ??
                       (_parametrosManutencao = FabricaParametrosManutencao.Criar(this));
            }
        }
    }
}