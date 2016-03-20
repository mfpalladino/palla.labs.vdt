// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class SumarioSituacaoDto
    {
        public int PercentualOk { get; set; }
        public int PercentualAtencao { get; set; }
        public int PercentualCritico { get; set; }
        public int PercentualInconclusivo { get; set; }
    }
}