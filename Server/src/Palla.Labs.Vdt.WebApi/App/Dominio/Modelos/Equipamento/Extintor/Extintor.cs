using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Extintor : Equipamento
    {
        private readonly string _numeroCilindro;
        private readonly string _agente;
        private readonly string _localizacao;
        private readonly long _fabricadoEm;

        public Extintor(Guid clienteId, string numeroCilindro,
            string agente, string localizacao, long fabricadoEm, IList<Manutencao> manutencoes)
            : this(Guid.NewGuid(), clienteId, numeroCilindro, agente, localizacao, fabricadoEm, manutencoes)
        {
        }

        public Extintor(Guid id, Guid clienteId, string numeroCilindro,
            string agente, string localizacao, long fabricadoEm, IList<Manutencao> manutencoes)
            : base(id, clienteId, manutencoes, TipoEquipamento.Extintor)
        {
            _numeroCilindro = numeroCilindro;
            _agente = agente;
            _localizacao = localizacao;
            _fabricadoEm = fabricadoEm;

            Validar();
        }

        public string NumeroCilindro
        {
            get { return _numeroCilindro; }
        }

        public string Agente
        {
            get { return _agente; }
        }

        public string Localizacao
        {
            get { return _localizacao; }
        }

        public long FabricadoEm
        {
            get { return _fabricadoEm; }
        }

        private void Validar()
        {
            if (String.IsNullOrWhiteSpace(NumeroCilindro))
                throw new FormatoInvalido("O número do cilindro do extintor deve ser informado.");

            if (NumeroCilindro.Length > 50)
                throw new FormatoInvalido("O número do cilindro do extintor não pode ter mais de 50 caracteres.");

            if (String.IsNullOrWhiteSpace(Agente))
                throw new FormatoInvalido("O agente do extintor deve ser informado.");

            if (Agente.Length > 100)
                throw new FormatoInvalido("O agente do extintor não pode ter mais de 100 caracteres.");

            if (String.IsNullOrWhiteSpace(Localizacao))
                throw new FormatoInvalido("A localização do extintor deve ser informada.");

            if (Localizacao.Length > 200)
                throw new FormatoInvalido("A localização do extintor não pode ter mais de 200 caracteres.");

            if (FabricadoEm < 0)
                throw new FormatoInvalido("A data da fabricação do extintor não é válida.");
        }

        public override string Nome
        {
            get { return String.Format("Extintor (cilindro: {0})", NumeroCilindro); }
        }
    }
}