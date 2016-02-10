using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos.Equipamento
{
    public class Mangueira : EquipamentoBase
    {
        private readonly TipoMangueira _tipoMangueira;
        private readonly DiametroMangueira _diametro;
        private readonly ComprimentoMangueira _comprimento;

        public Mangueira(TipoMangueira tipoMangueira,
            DiametroMangueira diametro, ComprimentoMangueira comprimento)
            : this(Guid.NewGuid(), tipoMangueira, diametro, comprimento)
        {
        }

        public Mangueira(Guid id, TipoMangueira tipoMangueira,
            DiametroMangueira diametro, ComprimentoMangueira comprimento)
            : base(id, TipoEquipamento.Mangueira)
        {
            _tipoMangueira = tipoMangueira;
            _diametro = diametro;
            _comprimento = comprimento;
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
    }
}