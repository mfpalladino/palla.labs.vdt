using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class GrupoDto : DtoBase<Guid>
    {
        public string Nome { get; set; }
    }
}