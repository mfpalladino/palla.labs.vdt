using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorCnpj
    {
        private string _numero;

        public ConstrutorCnpj ComNumeroEspecifico(string numero)
        {
            _numero = numero;
            return this;
        }

        public Cnpj Construir()
        {
            return new Cnpj(_numero ?? "14847133000102");
        }
    }
}