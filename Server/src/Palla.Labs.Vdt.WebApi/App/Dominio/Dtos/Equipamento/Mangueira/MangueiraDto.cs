using Palla.Labs.Vdt.App.Dominio.Modelos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class MangueiraDto : EquipamentoDto
    {
        public TipoMangueira TipoMangueira { get; set; }

        public DiametroMangueira Diametro { get; set; }

        public ComprimentoMangueira Comprimento { get; set; }
    }
}