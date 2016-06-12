using System;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class CriadorCliente
    {
        private readonly RepositorioClientes _repositorioClientes;
        private readonly RepositorioGrupos _repositorioGrupos;
        private readonly FabricaCliente _fabricaCliente;

        public CriadorCliente(RepositorioClientes repositorioClientes, RepositorioGrupos repositorioGrupos, FabricaCliente fabricaCliente)
        {
            _repositorioClientes = repositorioClientes;
            _repositorioGrupos = repositorioGrupos;
            _fabricaCliente = fabricaCliente;
        }

        public Cliente Criar(Guid siteId, ClienteDto clienteDto)
        {
            Validar(siteId, clienteDto);

            var cliente = _fabricaCliente.Criar(siteId, Guid.NewGuid(), clienteDto);
            _repositorioClientes.Inserir(cliente);
            return cliente;
        }

        private void Validar(Guid siteId, ClienteDto clienteDto)
        {
            if (clienteDto.Id != Guid.Empty)
                throw new FormatoInvalido("O identificador de cliente não deve ser informado neste contexto.");

            if (!clienteDto.GrupoId.GuidValido())
                throw new FormatoInvalido("O identificador de grupo do cliente não é válido.");

            if (!String.IsNullOrWhiteSpace(clienteDto.Nome) && _repositorioClientes.BuscarPorNome(siteId, clienteDto.Nome) != null)
                throw new JaExisteUmRecursoComEstasCaracteristicas("Já existe um cliente informado com este nome.");

            if (!String.IsNullOrWhiteSpace(clienteDto.Cnpj) && _repositorioClientes.BuscarPorCnpj(siteId, clienteDto.Cnpj) != null)
                throw new JaExisteUmRecursoComEstasCaracteristicas("Já existe um cliente informado com este CNPJ.");

            if (!String.IsNullOrWhiteSpace(clienteDto.Codigo) && _repositorioClientes.BuscarPorCodigo(siteId, clienteDto.Codigo) != null)
                throw new JaExisteUmRecursoComEstasCaracteristicas("Já existe um cliente informado com este código.");

            if (clienteDto.GrupoId.GuidValido() && _repositorioGrupos.BuscarPorId(siteId, clienteDto.GrupoId.ParaGuid()) == null)
                throw new FormatoInvalido("O grupo informado para o cliente não existe.");
        }
    }
}