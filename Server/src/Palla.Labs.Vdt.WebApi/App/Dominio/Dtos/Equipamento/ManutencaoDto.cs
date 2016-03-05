using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class ManutencaoDto : DtoBase<Guid>
    {
        public long Data { get; set; }
        public string Parte { get; set; }
    }
}