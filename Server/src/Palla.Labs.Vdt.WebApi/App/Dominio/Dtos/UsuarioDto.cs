using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class UsuarioDto : DtoBase<Guid>
    {
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public string Senha { get; set; }
        public Guid[] Grupos { get; set; }
        public bool EstaAtivo { get; set; }

        public string TipoNome
        {
            get
            {
                if (Tipo == 1)
                    return "Administrador";
                if (Tipo == 2)
                    return "Manutenedor";

                return "Consumidor";
            }
        }
    }
}