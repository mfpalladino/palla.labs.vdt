using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos.Equipamento
{
    public class Extintor : EquipamentoBase
    {
        private readonly string _numeroCilindro;
        private readonly string _agente;
        private readonly string _localizacao;
        private readonly DateTime _fabricadoEm;

        public Extintor(string numeroCilindro,
            string agente, string localizacao, DateTime fabricadoEm)
            : this(Guid.NewGuid(), numeroCilindro, agente, localizacao, fabricadoEm)
        {
        }

        public Extintor(Guid id, string numeroCilindro,
            string agente, string localizacao, DateTime fabricadoEm)
            : base(id, TipoEquipamento.Extintor)
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