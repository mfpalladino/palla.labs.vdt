// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class CorreioEletronico
    {
        private readonly string _endereco;

        public CorreioEletronico(string endereco)
        {
            _endereco = endereco;
        }

        public static implicit operator CorreioEletronico(string correioEletronico)
        {
            return correioEletronico == null ? null : new CorreioEletronico(correioEletronico);
        }

        public string Endereco
        {
            get { return _endereco; }
        }

        public override string ToString()
        {
            return _endereco;
        }

        public void Validar(string nome)
        {
            //todo
        }
    }
}