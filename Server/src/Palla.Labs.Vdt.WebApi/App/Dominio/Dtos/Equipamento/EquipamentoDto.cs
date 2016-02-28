using System;
using Palla.Labs.Vdt.App.Dominio.Modelos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public abstract class EquipamentoDto : DtoBase<Guid>
    {
        public Guid ClienteId { get; set; }

        public TipoEquipamento Tipo { get; set; }
    }
}