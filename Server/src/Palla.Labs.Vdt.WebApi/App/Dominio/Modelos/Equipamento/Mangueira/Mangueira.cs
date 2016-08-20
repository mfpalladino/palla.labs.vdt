using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Mangueira : Equipamento
    {
        private readonly TipoMangueira _tipoMangueira;
        private readonly DiametroMangueira _diametro;
        private readonly ComprimentoMangueira _comprimento;

        public Mangueira(Guid siteId, Guid clienteId, TipoMangueira tipoMangueira, DiametroMangueira diametro, ComprimentoMangueira comprimento, IList<Manutencao> manutencoes)
            : this(siteId, Guid.NewGuid(), clienteId, tipoMangueira, diametro, comprimento, manutencoes, true)
        {
        }

        public Mangueira(Guid siteId, Guid clienteId, TipoMangueira tipoMangueira, DiametroMangueira diametro, ComprimentoMangueira comprimento, IList<Manutencao> manutencoes, bool estaAtivo)
            : this(siteId, Guid.NewGuid(), clienteId, tipoMangueira, diametro, comprimento, manutencoes, estaAtivo)
        {
        }

        public Mangueira(Guid siteId, Guid id, Guid clienteId, TipoMangueira tipoMangueira,
            DiametroMangueira diametro, ComprimentoMangueira comprimento, IList<Manutencao> manutencoes)
            : this(siteId, id, clienteId, tipoMangueira,
            diametro, comprimento, manutencoes, true)
        {
        }

        public Mangueira(Guid siteId, Guid id, Guid clienteId, TipoMangueira tipoMangueira,
            DiametroMangueira diametro, ComprimentoMangueira comprimento, IList<Manutencao> manutencoes, bool estaAtivo)
            : base(siteId, id, clienteId, manutencoes, TipoEquipamento.Mangueira, estaAtivo)
        {
            _tipoMangueira = tipoMangueira;
            _diametro = diametro;
            _comprimento = comprimento;

            Validar();
        }

        public TipoMangueira TipoMangueira
        {
            get { return _tipoMangueira; }
        }

        public DiametroMangueira Diametro
        {
            get { return _diametro; }
        }

        public ComprimentoMangueira Comprimento
        {
            get { return _comprimento; }
        }

        private void Validar()
        {
        }

        public override string Nome
        {
            get { return "Mangueira"; }
        }
    }
}