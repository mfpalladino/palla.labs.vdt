using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao.Dtos
{
    public class GrupoDto : DtoBase<Guid>
    {
        public string Nome { get; set; }
    }
}