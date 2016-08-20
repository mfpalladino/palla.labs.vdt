using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class SistemaContraIncendioEmCoifa : Equipamento
    {
        private readonly string _central;
        private readonly int _quantidadeCilindroCo2;
        private readonly int _pesoCilindroCo2;
        private readonly int _quantidadeCilindroSaponificante;

        public SistemaContraIncendioEmCoifa(Guid siteId, Guid clienteId, string central,
            int quantidadeCilindroCo2, int pesoCilindroCo2, int quantidadeCilindroSaponificante, IList<Manutencao> manutencoes)
            : this(siteId, Guid.NewGuid(), clienteId, central, quantidadeCilindroCo2, pesoCilindroCo2, quantidadeCilindroSaponificante, manutencoes, true)
        {
        }

        public SistemaContraIncendioEmCoifa(Guid siteId, Guid clienteId, string central,
            int quantidadeCilindroCo2, int pesoCilindroCo2, int quantidadeCilindroSaponificante, IList<Manutencao> manutencoes, bool estaAtivo)
            : this(siteId, Guid.NewGuid(), clienteId, central, quantidadeCilindroCo2, pesoCilindroCo2, quantidadeCilindroSaponificante, manutencoes, estaAtivo)
        {
        }

        public SistemaContraIncendioEmCoifa(Guid siteId, Guid id, Guid clienteId, string central,
            int quantidadeCilindroCo2, int pesoCilindroCo2, int quantidadeCilindroSaponificante,
            IList<Manutencao> manutencoes)
            : this(siteId, id, clienteId, central,
            quantidadeCilindroCo2, pesoCilindroCo2, quantidadeCilindroSaponificante,
            manutencoes, true)
        {
        }

        public SistemaContraIncendioEmCoifa(Guid siteId, Guid id, Guid clienteId, string central,
            int quantidadeCilindroCo2, int pesoCilindroCo2, int quantidadeCilindroSaponificante, IList<Manutencao> manutencoes, bool estaAtivo)
            : base(siteId, id, clienteId, manutencoes, TipoEquipamento.SistemaContraIncendioEmCoifa, estaAtivo)
        {
            _central = central;
            _quantidadeCilindroCo2 = quantidadeCilindroCo2;
            _pesoCilindroCo2 = pesoCilindroCo2;
            _quantidadeCilindroSaponificante = quantidadeCilindroSaponificante;

            Validar();
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

        private void Validar()
        {
            if (String.IsNullOrWhiteSpace(Central))
                throw new FormatoInvalido("A central do sistema contra incêndio deve ser informada.");

            if (Central.Length > 120)
                throw new FormatoInvalido("A central do sistema contra incêndio não pode ter mais do que 120 caracteres.");


            if (QuantidadeCilindroCo2 < 0)
                throw new FormatoInvalido("A quantidade de cilindros CO2 do sistema contra incêndio não pode ser menor que zero.");

            if (PesoCilindroCo2 < 0)
                throw new FormatoInvalido("O peso do cilindro CO2 do sistema contra incêndio não pode ser menor que zero.");

            if (QuantidadeCilindroSaponificante < 0)
                throw new FormatoInvalido("A quantidade de cilindros saponificantes do sistema contra incêndio não pode ser menor que zero.");
        }

        public override string Nome
        {
            get { return String.Format("Sistema contra incêndio em coifa (Central: {0})", Central); }
        }
    }
}