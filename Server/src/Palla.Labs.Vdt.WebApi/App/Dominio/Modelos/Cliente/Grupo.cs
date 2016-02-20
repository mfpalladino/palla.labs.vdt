using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Grupo
    {
        private readonly Guid _id;
        private readonly string _nome;

        public Grupo(string nome):this(new Guid(), nome)
        {
        }

        public Grupo(Guid id, string nome)
        {
            _id = id;
            _nome = nome;
        }

        public Guid Id
        {
            get { return _id; }
        }

        public string Nome
        {
            get { return _nome; }
        }
    }
}