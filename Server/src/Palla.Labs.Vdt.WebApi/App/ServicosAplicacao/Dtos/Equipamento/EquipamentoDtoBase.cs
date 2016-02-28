using System;
using Palla.Labs.Vdt.App.Dominio.Modelos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao.Dtos
{
    public abstract class EquipamentoDtoBase : DtoBase<Guid>
    {
        public Guid ClienteId { get; set; }

        public TipoEquipamento Tipo { get; set; }
    }
}