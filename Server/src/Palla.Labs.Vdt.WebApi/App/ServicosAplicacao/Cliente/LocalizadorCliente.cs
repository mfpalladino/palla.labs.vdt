using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class LocalizadorCliente
    {
        private readonly RepositorioClientes _repositorioClientes;
        private readonly FabricaClienteDto _fabricaClienteDto;

        public LocalizadorCliente(RepositorioClientes repositorioClientes, FabricaClienteDto fabricaClienteDto)
        {
            _repositorioClientes = repositorioClientes;
            _fabricaClienteDto = fabricaClienteDto;
        }

        public ClienteDto Localizar(Guid siteId, string id)
        {
            Validar(siteId, id);
            return _fabricaClienteDto.Criar(siteId, _repositorioClientes.BuscarPorId(siteId, new Guid(id)));
        }

        public IEnumerable<ClienteDto> Localizar(Guid siteId)
        {
            return _fabricaClienteDto.Criar(siteId, _repositorioClientes.Buscar(siteId));
        }

        private void Validar(Guid siteId, string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de cliente informado não é válido.");

            if (_repositorioClientes.BuscarPorId(siteId, new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Cliente não encontrado");
        }
    }
}