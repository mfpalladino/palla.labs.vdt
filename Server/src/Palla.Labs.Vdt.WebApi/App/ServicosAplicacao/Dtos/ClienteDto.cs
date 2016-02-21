using System;

namespace Palla.Labs.Vdt.App.ServicosAplicacao.Dtos
{
    public class ClienteDto : DtoBase<Guid>
    {
        public string Nome { get; set; }

        public string Cnpj  { get; set; }

        public string Codigo { get; set; }

        public string GrupoId  { get; set; }

        public string EnderecoLogradouro  { get; set; }

        public string EnderecoNumero { get; set; }

        public string EnderecoComplemento { get; set; }

        public string EnderecoBairro { get; set; }

        public string EnderecoCidade { get; set; }

        public string EnderecoEstado { get; set; }

        public string EnderecoCep { get; set; }

        public string CorreioEletronicoLoja { get; set; }

        public string CorreioEletronicoManutencao { get; set; }

        public string CorreioEletronicoAdministracao { get; set; }
    }
}