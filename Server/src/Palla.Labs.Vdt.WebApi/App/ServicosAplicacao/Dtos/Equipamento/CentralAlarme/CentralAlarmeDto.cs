using Palla.Labs.Vdt.App.Dominio.Modelos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao.Dtos
{
    public class CentralAlarmeDtoBase : EquipamentoDtoBase
    {
        public string Fabricante { get; set; }

        public string Modelo { get; set; }

        public TipoCentralAlarme TipoCentralAlarme { get; set; }

        public int QuantidadeDetectores { get; set; }

        public bool DetectorEnderecavel { get; set; }

        public int QuantidadeAcionadores { get; set; }

        public int QuantidadeSirenes { get; set; }
    }
}