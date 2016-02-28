using System;
using AutoMapper;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.AutoMapper;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ModificadorCliente
    {
        private readonly RepositorioClientes _repositorioClientes;
        private readonly RepositorioGrupos _repositorioGrupos;
        private readonly IMapper _mapeador;

        public ModificadorCliente(RepositorioClientes repositorioClientes, RepositorioGrupos repositorioGrupos, IMapper mapeador)
        {
            _repositorioClientes = repositorioClientes;
            _repositorioGrupos = repositorioGrupos;
            _mapeador = mapeador;
        }

        public void Modificar(string id, ClienteDto clienteDto)
        {
            Validar(id, clienteDto);
            _repositorioClientes.Editar(_mapeador.ParaEntidade<Cliente, ClienteDto>(id.ParaGuid(), clienteDto));
        }

        private void Validar(string id, ClienteDto clienteDto)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de cliente informado não é válido.");

            if (_repositorioClientes.BuscarPorId(new Guid(id)) == null)
                throw new RecursoNaoEncontrado("O cliente não foi encontrado.");

            if (!String.IsNullOrWhiteSpace(clienteDto.Nome) && _repositorioClientes.BuscarPorNomeExcetoId(clienteDto.Nome, id.ParaGuid()) != null)
                throw new JaExisteUmRecursoComEstasCaracteristicas("Já existe um cliente informado com este nome.");

            if (!String.IsNullOrWhiteSpace(clienteDto.Cnpj) && _repositorioClientes.BuscarPorCnpjExcetoId(clienteDto.Cnpj, id.ParaGuid()) != null)
                throw new JaExisteUmRecursoComEstasCaracteristicas("Já existe um cliente informado com este CNPJ.");

            if (!String.IsNullOrWhiteSpace(clienteDto.Codigo) && _repositorioClientes.BuscarPorCodigoExcetoId(clienteDto.Codigo, id.ParaGuid()) != null)
                throw new JaExisteUmRecursoComEstasCaracteristicas("Já existe um cliente informado com este código.");

            if (clienteDto.GrupoId.GuidValido() && _repositorioGrupos.BuscarPorId(clienteDto.GrupoId.ParaGuid()) == null)
                throw new FormatoInvalido("O grupo informado para o cliente não existe.");
        }
    }
}