using System;
using System.Collections.Generic;
using AutoMapper;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class LocalizadorCliente
    {
        private readonly RepositorioClientes _repositorioClientes;
        private readonly IMapper _mapeador;

        public LocalizadorCliente(RepositorioClientes repositorioClientes, IMapper mapeador)
        {
            _repositorioClientes = repositorioClientes;
            _mapeador = mapeador;
        }

        public ClienteDto Localizar(string id)
        {
            Validar(id);
            return _mapeador.Map<ClienteDto>(_repositorioClientes.BuscarPorId(new Guid(id)));
        }

        public IEnumerable<ClienteDto> Localizar()
        {
            return _mapeador.Map<IEnumerable<ClienteDto>>(_repositorioClientes.Buscar());
        }

        private void Validar(string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de cliente informado não é válido.");

            if (_repositorioClientes.BuscarPorId(new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Cliente não encontrado");
        }
    }
}