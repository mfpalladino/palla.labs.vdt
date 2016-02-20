// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Endereco
    {
        private readonly string _logradouro;
        private readonly string _numero;
        private readonly string _complemento;
        private readonly string _bairro;
        private readonly string _cidade;
        private readonly string _estado;
        private readonly string _cep;

        public Endereco(string logradouro,
            string numero,
            string complemento,
            string bairro,
            string cidade,
            string estado,
            string cep)
        {
            _logradouro = logradouro;
            _numero = numero;
            _complemento = complemento;
            _bairro = bairro;
            _cidade = cidade;
            _estado = estado;
            _cep = cep;
        }

        public string Logradouro 
        {
            get { return _logradouro; }
        }

        public string Numero
        {
            get { return _numero; }
        }

        public string Complemento
        {
            get { return _complemento; }
        }

        public string Bairro
        {
            get { return _bairro; }
        }

        public string Cidade
        {
            get { return _cidade; }
        }

        public string Estado
        {
            get { return _estado; }
        }

        public string Cep
        {
            get { return _cep; }
        }
    }
}