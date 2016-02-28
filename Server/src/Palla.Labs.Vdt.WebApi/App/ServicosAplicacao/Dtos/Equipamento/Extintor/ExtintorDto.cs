using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao.Dtos
{
    public class ExtintorDtoBase : EquipamentoDtoBase
    {
        public string NumeroCilindro { get; set; }

        public string Agente { get; set; }

        public string Localizacao { get; set; }

        public DateTime FabricadoEm { get; set; }
    }
}