using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorEndereco
    {
        public Endereco Construir()
        {
            return new Endereco("logradouro", "numero", "complemento", "bairro", "cidade", "SP", "cep");
        }
    }
}