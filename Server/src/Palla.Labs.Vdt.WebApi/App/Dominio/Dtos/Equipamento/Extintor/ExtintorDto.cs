// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class ExtintorDto : EquipamentoDto
    {
        public string NumeroCilindro { get; set; }

        public string Agente { get; set; }

        public string Localizacao { get; set; }

        public long FabricadoEm { get; set; }
    }
}