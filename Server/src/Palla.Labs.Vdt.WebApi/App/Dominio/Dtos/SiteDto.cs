using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class SiteDto : DtoBase<Guid>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}