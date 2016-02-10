using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Manutencao
    {
        private readonly DateTime _data;
        private readonly string _parte;

        public Manutencao(DateTime data, string parte)
        {
            _data = data;
            _parte = parte;
        }

        public DateTime Data
        {
            get { return _data; }
        }

        public string Parte
        {
            get { return _parte; }
        }
    }
}