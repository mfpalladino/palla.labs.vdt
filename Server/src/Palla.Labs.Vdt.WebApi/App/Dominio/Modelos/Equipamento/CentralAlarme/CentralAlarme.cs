using System;
using System.Collections.Generic;

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

        public CentralAlarme(Guid customerId, string fabricante,
            string modelo,
            TipoCentralAlarme tipoCentralAlarme,
            int quantidadeDetectores,
            bool detectorEnderecavel,
            int quantidadeAcionadores,
            int quantidadeSirenes,
            IList<Manutencao> manutencoes)
            : this(Guid.NewGuid(), customerId, fabricante,
                modelo,
                tipoCentralAlarme,
                quantidadeDetectores,
                detectorEnderecavel,
                quantidadeAcionadores,
                quantidadeSirenes,
                manutencoes)
        {
        }

        public CentralAlarme(Guid id, Guid customerId, string fabricante,
            string modelo, 
            TipoCentralAlarme tipoCentralAlarme, 
            int quantidadeDetectores, 
            bool detectorEnderecavel,
            int quantidadeAcionadores,
            int quantidadeSirenes,
            IList<Manutencao> manutencoes)
            : base(id, customerId, manutencoes, TipoEquipamento.CentralAlarme)
        {
            _fabricante = fabricante;
            _modelo = modelo;
            _tipoCentralAlarme = tipoCentralAlarme;
            _quantidadeDetectores = quantidadeDetectores;
            _detectorEnderecavel = detectorEnderecavel;
            _quantidadeAcionadores = quantidadeAcionadores;
            _quantidadeSirenes = quantidadeSirenes;
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
    }
}