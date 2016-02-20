using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorCorreioEletronico
    {
        private string _correioEletronico;

        public ConstrutorCorreioEletronico ComEnderecoEspecifico(string correioEletronico)
        {
            _correioEletronico = correioEletronico;
            return this;
        }

        public CorreioEletronico Construir()
        {
            return new CorreioEletronico(_correioEletronico ?? "correioeletronico@teste.com.br");
        }
    }
}