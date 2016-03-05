using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Manutencao
    {
        private readonly Guid _id;
        private readonly long _data;
        private readonly string _parte;

        public Manutencao(long data, string parte):this(Guid.NewGuid(), data, parte)
        {
        }

        public Manutencao(Guid id, long data, string parte)
        {
            _id = id;
            _data = data;
            _parte = parte;
        }

        public Guid Id
        {
            get { return _id; }
        }

        public long Data
        {
            get { return _data; }
        }

        public string Parte
        {
            get { return _parte; }
        }
    }
}