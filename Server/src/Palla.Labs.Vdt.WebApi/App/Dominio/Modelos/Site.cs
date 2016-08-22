using System;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Site : EntidadeBase<Guid>
    {
        private const int DiaDeVencimentoPadrao = 15;

        private readonly string _nome;
        private readonly bool _estaAtivo;
        private readonly int _diaVencimento;

        public Site(string nome)
            : this(Guid.NewGuid(), nome, true, DiaDeVencimentoPadrao)
        {
        }

        public Site(string nome, bool estaAtivo)
            : this(Guid.NewGuid(), nome, estaAtivo, DiaDeVencimentoPadrao)
        {
        }

        public Site(string nome, bool estaAtivo, int diaVencimento)
            : this(Guid.NewGuid(), nome, estaAtivo, diaVencimento)
        {
        }

        public Site(Guid id, string nome)
            : this(id, nome, true, DiaDeVencimentoPadrao)
        {
        }

        public Site(Guid id, string nome, bool estaAtivo)
            : this(id, nome, estaAtivo, DiaDeVencimentoPadrao)
        {
        }

        public Site(Guid id, string nome, bool estaAtivo, int diaVencimento)
            : base(id)
        {
            _nome = nome;
            _estaAtivo = estaAtivo;
            _diaVencimento = diaVencimento;

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

        public int DiaVencimento
        {
            get { return _diaVencimento; }
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new FormatoInvalido("O nome do site deve ser informado.");

            if (Nome.Length > 50)
                throw new FormatoInvalido("O nome do site não pode ter mais de 50 caracteres.");

            if (DiaVencimento < 1 || DiaVencimento > 30)
                throw new FormatoInvalido("O dia do vencimento não é válido.");
        }
    }
}