// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Cnpj
    {
        private readonly string _numero;

        public Cnpj(string cnpj)
        {
            _numero = cnpj;
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
    }
}