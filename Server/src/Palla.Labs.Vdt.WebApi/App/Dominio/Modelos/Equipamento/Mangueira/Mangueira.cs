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

        public Mangueira(Guid customerId, TipoMangueira tipoMangueira, DiametroMangueira diametro, ComprimentoMangueira comprimento, IList<Manutencao> manutencoes)
            : this(Guid.NewGuid(), customerId, tipoMangueira, diametro, comprimento, manutencoes)
        {
        }

        public Mangueira(Guid id, Guid customerId, TipoMangueira tipoMangueira,
            DiametroMangueira diametro, ComprimentoMangueira comprimento, IList<Manutencao> manutencoes)
            : base(id, customerId, manutencoes, TipoEquipamento.Mangueira)
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