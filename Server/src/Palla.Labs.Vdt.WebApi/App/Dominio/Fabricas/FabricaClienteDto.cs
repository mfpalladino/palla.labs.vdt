using System;
using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaClienteDto
    {
        private readonly RepositorioGrupos _repositorioGrupos;

        public FabricaClienteDto(RepositorioGrupos repositorioGrupos)
        {
            _repositorioGrupos = repositorioGrupos;
        }

        public virtual IEnumerable<ClienteDto> Criar(Guid siteId, IEnumerable<Cliente> clientes)
        {
            return clientes.Select(x => Criar(siteId, x));
        }

        public virtual ClienteDto Criar(Guid siteId, Cliente cliente)
        {
            var grupo = _repositorioGrupos.BuscarPorId(siteId, cliente.GrupoId);

            return new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cnpj = cliente.Cnpj.ToString(),
                Codigo = cliente.Codigo,
                GrupoId = cliente.GrupoId.ToString(),
                GrupoNome = grupo != null ? grupo.Nome : String.Empty,
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