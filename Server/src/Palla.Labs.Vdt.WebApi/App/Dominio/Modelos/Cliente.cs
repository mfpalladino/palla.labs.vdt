﻿using System;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Usuario : EntidadeBase<Guid>
    {
        private readonly string _nome;
        private readonly string _senha;
        private readonly Guid _siteId;

        protected Usuario() //usado apenas para mapeamento e testes
        {
        }

        public Usuario(
            Guid siteId,
            string nome,
            string senha)
            : this(siteId, Guid.NewGuid(), nome, senha)
        {
        }

        public Usuario(
            Guid siteId,
            Guid id,
            string nome, 
            string senha):base(id)
        {
            _siteId = siteId;
            _nome = nome;
            _senha = senha;

            Validar();
        }

        public string Nome
        {
            get { return _nome; }
        }

        public string Senha
        {
            get { return _senha; }
        }

        public Guid SiteId
        {
            get { return _siteId; }
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new FormatoInvalido("O nome do usuário deve ser informado.");

            if (Nome.Length > 30)
                throw new FormatoInvalido("O nome do usuário não pode ter mais de 30 caracteres.");

            if (string.IsNullOrWhiteSpace(Senha))
                throw new FormatoInvalido("O código do cliente deve ser informado.");

            if (SiteId == Guid.Empty)
                throw new FormatoInvalido("O site do usuário deve ser informado.");
        }
    }
}