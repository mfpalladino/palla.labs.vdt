
// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao.Dtos
{
    public class SistemaContraIncendioEmCoifaDtoBase : EquipamentoDtoBase
    {
        public string Central { get; set; }
        public int QuantidadeCilindroCo2 { get; set; }
        public int PesoCilindroCo2 { get; set; }
        public int QuantidadeCilindroSaponificante { get; set; }
    }
}