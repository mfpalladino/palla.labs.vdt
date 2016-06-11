using System;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Site : EntidadeBase<Guid>
    {
        private readonly string _nome;

        public Site(string nome):this(Guid.NewGuid(), nome)
        {
        }

        public Site(Guid id, string nome)
            : base(id)
        {
            _nome = nome;

            Validar();
        }

        public string Nome
        {
            get { return _nome; }
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new FormatoInvalido("O nome do site deve ser informado.");

            if (Nome.Length > 50)
                throw new FormatoInvalido("O nome do site não pode ter mais de 50 caracteres.");
        }
    }
}