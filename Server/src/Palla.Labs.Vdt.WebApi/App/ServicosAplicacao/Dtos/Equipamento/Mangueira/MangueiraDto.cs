using Palla.Labs.Vdt.App.Dominio.Modelos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao.Dtos
{
    public class MangueiraDtoBase : EquipamentoDtoBase
    {
        public TipoMangueira TipoMangueira { get; set; }

        public DiametroMangueira Diametro { get; set; }

        public ComprimentoMangueira Comprimento { get; set; }
    }
}