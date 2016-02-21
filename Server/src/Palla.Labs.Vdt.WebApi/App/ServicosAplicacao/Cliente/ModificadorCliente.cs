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
        private readonly IMapper _mapeador;

        public ModificadorCliente(RepositorioClientes repositorioClientes, IMapper mapeador)
        {
            _repositorioClientes = repositorioClientes;
            _mapeador = mapeador;
        }

        public void Modificar(string id, ClienteDto clienteDto)
        {
            Validar(id);
            _repositorioClientes.Editar(_mapeador.ParaEntidade<Cliente, ClienteDto>(id.ParaGuid(), clienteDto));
        }

        private void Validar(string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de cliente informado não é válido.");

            if (_repositorioClientes.ListarPorId(new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Cliente não encontrado");
        }
    }
}