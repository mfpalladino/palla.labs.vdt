using System;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Site : EntidadeBase<Guid>
    {
        private readonly string _nome;
        private readonly bool _estaAtivo;

        public Site(string nome)
            : this(Guid.NewGuid(), nome, true)
        {
        }

        public Site(string nome, bool estaAtivo)
            : this(Guid.NewGuid(), nome, estaAtivo)
        {
        }

        public Site(Guid id, string nome)
            : this(id, nome, true)
        {
        }

        public Site(Guid id, string nome, bool estaAtivo)
            : base(id)
        {
            _nome = nome;
            _estaAtivo = estaAtivo;

            Validar();
        }

        public string Nome
        {
            get { return _nome; }
        }

        public bool EstaAtivo
        {
            get { return _estaAtivo; }
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