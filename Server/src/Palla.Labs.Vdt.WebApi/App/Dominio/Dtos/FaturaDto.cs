using System;

namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class FaturaDto : DtoBase<Guid>
    {
        public int Mes { get; set; }

        public int Ano { get; set; }

        public int QuantidadeEquipamentos { get; set; }

        public decimal ValorPorEquipamento { get; set; }

        public int QuantidadeUsuarios { get; set; }

        public decimal ValorPorUsuario { get; set; }

        public decimal Descontos { get; set; }

        public decimal Total { get; set; }
    }
}