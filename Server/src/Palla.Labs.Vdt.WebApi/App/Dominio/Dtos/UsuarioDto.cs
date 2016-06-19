using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class UsuarioDto : DtoBase<Guid>
    {
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public Guid[] Grupos { get; set; }
    }
}