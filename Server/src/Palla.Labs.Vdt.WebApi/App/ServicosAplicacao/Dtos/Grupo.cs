using System;

namespace Palla.Labs.Vdt.App.ServicosAplicacao.Dtos
{
    public class Grupo
    {
        public Grupo()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}