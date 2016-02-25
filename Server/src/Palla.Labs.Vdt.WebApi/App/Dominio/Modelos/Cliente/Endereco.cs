// ReSharper disable once CheckNamespace

using System;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

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

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(Logradouro))
                throw new FormatoInvalido("O logradouro do endereço deve ser informado.");

            if (Logradouro.Length > 200)
                throw new FormatoInvalido("O logradouro do endereço deve ter no máximo 200 caracteres.");

            if (String.IsNullOrWhiteSpace(Numero))
                throw new FormatoInvalido("O número do endereço deve ser informado.");

            if (Numero.Length > 20)
                throw new FormatoInvalido("O número do endereço deve ter no máximo 20 caracteres.");

            if (String.IsNullOrWhiteSpace(Bairro))
                throw new FormatoInvalido("O bairro do endereço deve ser informado.");

            if (Bairro.Length > 120)
                throw new FormatoInvalido("O bairro do endereço deve ter no máximo 120 caracteres.");

            if (String.IsNullOrWhiteSpace(Cidade))
                throw new FormatoInvalido("A cidade do endereço deve ser informada.");

            if (Cidade.Length > 80)
                throw new FormatoInvalido("A cidade do endereço deve ter no máximo 80 caracteres.");

            if (String.IsNullOrWhiteSpace(Estado))
                throw new FormatoInvalido("O estado do endereço deve ser informado.");

            if (Estado.Length != 2)
                throw new FormatoInvalido("O estado do endereço deve ter exatamente 2 caracteres.");

            if (String.IsNullOrWhiteSpace(Cep))
                throw new FormatoInvalido("O CEP do endereço deve ser informado.");

            if (Estado.Length > 10)
                throw new FormatoInvalido("O CEP do endereço deve ter no máximo 10 caracteres.");
        }
    }
}