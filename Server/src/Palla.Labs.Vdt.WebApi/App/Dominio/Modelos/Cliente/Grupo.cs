using System;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Grupo : EntidadeBase<Guid>
    {
        private readonly string _nome;
        private readonly Guid _siteId;

        public Grupo(Guid siteId, string nome)
            : this(siteId, Guid.NewGuid(), nome)
        {
        }

        public Grupo(Guid siteId, Guid id, string nome)
            : base(id)
        {
            _nome = nome;
            _siteId = siteId;

            Validar();
        }

        public string Nome
        {
            get { return _nome; }
        }

        public Guid SiteId
        {
            get { return _siteId; }
        }

        private void Validar()
        {
            if (String.IsNullOrWhiteSpace(Nome))
                throw new FormatoInvalido("O nome do grupo deve ser informado.");

            if (Nome.Length > 50)
                throw new FormatoInvalido("O nome do grupo não pode ter mais de 50 caracteres.");
        }
    }
}