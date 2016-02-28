using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaClienteDto
    {
        public virtual IEnumerable<ClienteDto> Criar(IEnumerable<Cliente> clientes)
        {
            return clientes.Select(Criar);
        }

        public virtual ClienteDto Criar(Cliente cliente)
        {
            return new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cnpj = cliente.Cnpj.ToString(),
                Codigo = cliente.Codigo,
                GrupoId = cliente.GrupoId.ToString(),
                Logradouro = cliente.Endereco.Logradouro,
                Numero = cliente.Endereco.Numero,
                Complemento = cliente.Endereco.Complemento,
                Bairro = cliente.Endereco.Bairro,
                Cidade = cliente.Endereco.Cidade,
                Estado = cliente.Endereco.Estado,
                Cep = cliente.Endereco.Cep,
                CorreioEletronicoLoja = cliente.CorreioEletronicoLoja.ToString(),
                CorreioEletronicoManutencao = cliente.CorreioEletronicoManutencao.ToString(),
                CorreioEletronicoAdministracao = cliente.CorreioEletronicoAdministracao.ToString()
            };
        }
    }
}