using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos.Equipamento
{
    public class CentralAlarme : EquipamentoBase
    {
        private readonly string _fabricante;
        private readonly string _modelo;
        private readonly TipoCentralAlarme _tipoCentralAlarme;
        private readonly int _quantidadeDetectores;
        private readonly bool _detectorEnderecavel;
        private readonly int _quantidadeAcionadores;
        private readonly int _quantidadeSirenes;

        public CentralAlarme(string fabricante,
            string modelo,
            TipoCentralAlarme tipoCentralAlarme,
            int quantidadeDetectores,
            bool detectorEnderecavel,
            int quantidadeAcionadores,
            int quantidadeSirenes)
            : this(Guid.NewGuid(), fabricante,
                modelo,
                tipoCentralAlarme,
                quantidadeDetectores,
                detectorEnderecavel,
                quantidadeAcionadores,
                quantidadeSirenes)
        {
        }

        public CentralAlarme(Guid id, string fabricante,
            string modelo, 
            TipoCentralAlarme tipoCentralAlarme, 
            int quantidadeDetectores, 
            bool detectorEnderecavel,
            int quantidadeAcionadores,
            int quantidadeSirenes)
            : base(id, TipoEquipamento.CentralAlarme)
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