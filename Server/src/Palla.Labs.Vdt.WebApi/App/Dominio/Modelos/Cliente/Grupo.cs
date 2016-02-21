﻿using System;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Grupo : EntidadeBase<Guid>
    {
        private readonly string _nome;

        public Grupo(string nome):this(Guid.NewGuid(), nome)
        {
        }

        public Grupo(Guid id, string nome) : base(id)
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
            if (String.IsNullOrWhiteSpace(Nome))
                throw new FormatoInvalido("O nome do grupo deve ser informado.");

            if (Nome.Length > 50)
                throw new FormatoInvalido("O nome do grupo não pode ter mais de 50 caracteres.");
        }
    }
}