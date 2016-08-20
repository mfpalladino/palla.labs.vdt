using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class CentralAlarme : Equipamento
    {
        private readonly string _fabricante;
        private readonly string _modelo;
        private readonly TipoCentralAlarme _tipoCentralAlarme;
        private readonly int _quantidadeDetectores;
        private readonly bool _detectorEnderecavel;
        private readonly int _quantidadeAcionadores;
        private readonly int _quantidadeSirenes;

        public CentralAlarme(Guid siteId, Guid clienteId, string fabricante,
            string modelo,
            TipoCentralAlarme tipoCentralAlarme,
            int quantidadeDetectores,
            bool detectorEnderecavel,
            int quantidadeAcionadores,
            int quantidadeSirenes,
            IList<Manutencao> manutencoes)
            : this(siteId, Guid.NewGuid(), clienteId, fabricante,
                modelo,
                tipoCentralAlarme,
                quantidadeDetectores,
                detectorEnderecavel,
                quantidadeAcionadores,
                quantidadeSirenes,
                manutencoes, true)
        {
        }

        public CentralAlarme(Guid siteId, Guid clienteId, string fabricante,
            string modelo,
            TipoCentralAlarme tipoCentralAlarme,
            int quantidadeDetectores,
            bool detectorEnderecavel,
            int quantidadeAcionadores,
            int quantidadeSirenes,
            IList<Manutencao> manutencoes, bool estaAtivo)
            : this(siteId, Guid.NewGuid(), clienteId, fabricante,
                modelo,
                tipoCentralAlarme,
                quantidadeDetectores,
                detectorEnderecavel,
                quantidadeAcionadores,
                quantidadeSirenes,
                manutencoes, estaAtivo)
        {
        }

        public CentralAlarme(Guid siteId, Guid id, Guid clienteId, string fabricante,
            string modelo,
            TipoCentralAlarme tipoCentralAlarme,
            int quantidadeDetectores,
            bool detectorEnderecavel,
            int quantidadeAcionadores,
            int quantidadeSirenes,
            IList<Manutencao> manutencoes)
            : this(siteId, id, clienteId, fabricante, modelo, tipoCentralAlarme, quantidadeDetectores, detectorEnderecavel, quantidadeAcionadores, quantidadeSirenes, manutencoes, true)
        {
        }

        public CentralAlarme(Guid siteId, Guid id, Guid clienteId, string fabricante,
            string modelo, 
            TipoCentralAlarme tipoCentralAlarme, 
            int quantidadeDetectores, 
            bool detectorEnderecavel,
            int quantidadeAcionadores,
            int quantidadeSirenes,
            IList<Manutencao> manutencoes, bool estaAtivo)
            : base(siteId, id, clienteId, manutencoes, TipoEquipamento.CentralAlarme, estaAtivo)
        {
            _fabricante = fabricante;
            _modelo = modelo;
            _tipoCentralAlarme = tipoCentralAlarme;
            _quantidadeDetectores = quantidadeDetectores;
            _detectorEnderecavel = detectorEnderecavel;
            _quantidadeAcionadores = quantidadeAcionadores;
            _quantidadeSirenes = quantidadeSirenes;

            Validar();
        }

        public string Fabricante
        {
            get { return _fabricante; }
        }
        public string Modelo
        {
            get { return _modelo; }
        }

        public TipoCentralAlarme TipoCentralAlarme
        {
            get { return _tipoCentralAlarme; }
        }

        public int QuantidadeDetectores
        {
            get { return _quantidadeDetectores; }
        }

        public bool DetectorEnderecavel
        {
            get { return _detectorEnderecavel; }
        }

        public int QuantidadeAcionadores
        {
            get { return _quantidadeAcionadores; }
        }

        public int QuantidadeSirenes
        {
            get { return _quantidadeSirenes; }
        }

        private void Validar()
        {
            if (String.IsNullOrWhiteSpace(Fabricante))
                throw new FormatoInvalido("O fabricante da central de alarme deve ser informado.");

            if (Fabricante.Length > 120)
                throw new FormatoInvalido("O fabricante da central de alarme não pode ter mais de 120 caracteres.");

            if (String.IsNullOrWhiteSpace(Modelo))
                throw new FormatoInvalido("O modelo da central de alarme deve ser informado.");

            if (Modelo.Length > 150)
                throw new FormatoInvalido("O modelo da central de alarme não pode ter mais de 150 caracteres.");

            if (QuantidadeDetectores < 0)
                throw new FormatoInvalido("A quantidade de detectores da central de alarme não pode ser menor que zero.");

            if (QuantidadeAcionadores < 0)
                throw new FormatoInvalido("A quantidade de acionadores da central de alarme não pode ser menor que zero.");

            if (QuantidadeSirenes < 0)
                throw new FormatoInvalido("A quantidade de sirenes da central de alarme não pode ser menor que zero.");
        }

        public override string Nome
        {
            get { return String.Format("Central de alarme (Fab: {0} Mod: {1})", Fabricante, Modelo); }
        }
    }
}