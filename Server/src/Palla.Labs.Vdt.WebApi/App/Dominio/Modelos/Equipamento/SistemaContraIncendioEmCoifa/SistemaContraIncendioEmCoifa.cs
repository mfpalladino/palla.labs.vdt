using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class SistemaContraIncendioEmCoifa : Equipamento
    {
        private readonly string _central;
        private readonly int _quantidadeCilindroCo2;
        private readonly int _pesoCilindroCo2;
        private readonly int _quantidadeCilindroSaponificante;

        public SistemaContraIncendioEmCoifa(Guid customerId, string central,
            int quantidadeCilindroCo2, int pesoCilindroCo2, int quantidadeCilindroSaponificante, IList<Manutencao> manutencoes)
            : this(Guid.NewGuid(), customerId, central, quantidadeCilindroCo2, pesoCilindroCo2, quantidadeCilindroSaponificante, manutencoes)
        {
        }

        public SistemaContraIncendioEmCoifa(Guid id, Guid customerId, string central,
            int quantidadeCilindroCo2, int pesoCilindroCo2, int quantidadeCilindroSaponificante, IList<Manutencao> manutencoes)
            : base(id, customerId, manutencoes, TipoEquipamento.SistemaContraIncendioEmCoifa)
        {
            _central = central;
            _quantidadeCilindroCo2 = quantidadeCilindroCo2;
            _pesoCilindroCo2 = pesoCilindroCo2;
            _quantidadeCilindroSaponificante = quantidadeCilindroSaponificante;
        }

        public string Central
        {
            get { return _central; }
        }
        public int QuantidadeCilindroCo2
        {
            get { return _quantidadeCilindroCo2; }
        }
        public int PesoCilindroCo2
        {
            get { return _pesoCilindroCo2; }
        }

        public int QuantidadeCilindroSaponificante
        {
            get { return _quantidadeCilindroSaponificante; }
        }
    }
}