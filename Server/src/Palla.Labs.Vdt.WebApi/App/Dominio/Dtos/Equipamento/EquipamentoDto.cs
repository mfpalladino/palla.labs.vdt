using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class EquipamentoDto : DtoBase<Guid>
    {
        public Guid ClienteId { get; set; }

        public int Tipo { get; set; }
    }
}