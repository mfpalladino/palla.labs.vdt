using System;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaCliente
    {
        public virtual Cliente Criar(Guid siteId, ClienteDto clienteDto)
        {
            return Criar(siteId, clienteDto.Id, clienteDto);
        }

        public virtual Cliente Criar(Guid siteId, Guid id, ClienteDto clienteDto)
        {
            return new Cliente(
                    siteId, 
                    id,
                    clienteDto.GrupoId.ParaGuid(),
                    new Cnpj(clienteDto.Cnpj),
                    clienteDto.Nome,
                    clienteDto.Codigo,
                    new Endereco(clienteDto.Logradouro, clienteDto.Numero, clienteDto.Complemento, clienteDto.Bairro, clienteDto.Cidade, clienteDto.Estado, clienteDto.Cep),
                    new CorreioEletronico(clienteDto.CorreioEletronicoLoja),
                    new CorreioEletronico(clienteDto.CorreioEletronicoManutencao),
                    new CorreioEletronico(clienteDto.CorreioEletronicoAdministracao));
        }
    }
}