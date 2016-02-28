using System;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Cnpj
    {
        private readonly string _numero;

        public Cnpj(string cnpj)
        {
            _numero = cnpj;

            Validar();
        }

        public static implicit operator Cnpj(string cnpj)
        {
            return cnpj == null ? null : new Cnpj(cnpj);
        }

        public string Numero
        {
            get { return _numero; }
        }

        public override string ToString()
        {
            return _numero;
        }

        public override bool Equals(object outroObjeto)
        {
            var cnpj = outroObjeto as Cnpj;
            return cnpj != null && Numero != null ? Numero.Equals(cnpj.Numero, StringComparison.CurrentCultureIgnoreCase) : base.Equals(outroObjeto);
        }

        public override int GetHashCode()
        {
            return Numero.GetHashCode();
        }

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(Numero))
                throw new FormatoInvalido("O CNPJ do cliente deve ser informado.");

            if (Numero.Length > 14)
                throw new FormatoInvalido("O CNPJ do cliente deve ser 14 caracteres.");

            if (!Numero.ContemSomenteDigitos())
                throw new FormatoInvalido("O CNPJ do cliente deve conter apenas números.");
        }
    }
}