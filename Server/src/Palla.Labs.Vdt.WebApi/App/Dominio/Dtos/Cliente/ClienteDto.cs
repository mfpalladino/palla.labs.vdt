using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class ClienteDto : DtoBase<Guid>
    {
        public string Nome { get; set; }

        public string Cnpj  { get; set; }

        public string Codigo { get; set; }

        public string GrupoId  { get; set; }

        public string Logradouro  { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Cep { get; set; }

        public string CorreioEletronicoLoja { get; set; }

        public string CorreioEletronicoManutencao { get; set; }

        public string CorreioEletronicoAdministracao { get; set; }
    }
}