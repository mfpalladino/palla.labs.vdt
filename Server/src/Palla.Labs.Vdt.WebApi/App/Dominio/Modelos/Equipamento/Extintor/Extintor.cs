using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Extintor : Equipamento
    {
        private readonly string _numeroCilindro;
        private readonly string _agente;
        private readonly string _localizacao;
        private readonly DateTime _fabricadoEm;

        public Extintor(Guid customerId, string numeroCilindro,
            string agente, string localizacao, DateTime fabricadoEm, IList<Manutencao> manutencoes)
            : this(Guid.NewGuid(), customerId, numeroCilindro, agente, localizacao, fabricadoEm, manutencoes)
        {
        }

        public Extintor(Guid id, Guid customerId, string numeroCilindro,
            string agente, string localizacao, DateTime fabricadoEm, IList<Manutencao> manutencoes)
            : base(id, customerId, manutencoes, TipoEquipamento.Extintor)
        {
            _numeroCilindro = numeroCilindro;
            _agente = agente;
            _localizacao = localizacao;
            _fabricadoEm = fabricadoEm;
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

        public DateTime FabricadoEm
        {
            get { return _fabricadoEm; }
        }
    }
}