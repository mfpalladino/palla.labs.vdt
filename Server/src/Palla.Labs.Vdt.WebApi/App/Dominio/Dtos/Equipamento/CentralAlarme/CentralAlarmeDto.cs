
// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class CentralAlarmeDto : EquipamentoDto
    {
        public string Fabricante { get; set; }

        public string Modelo { get; set; }

        public int TipoCentralAlarme { get; set; }

        public int QuantidadeDetectores { get; set; }

        public bool DetectorEnderecavel { get; set; }

        public int QuantidadeAcionadores { get; set; }

        public int QuantidadeSirenes { get; set; }
    }
}