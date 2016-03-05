using System;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public abstract class ValidadorEquipamentoBase : IValidadorEquipamento
    {
        private readonly RepositorioClientes _repositorioClientes;
        private readonly RepositorioEquipamentos _repositorioEquipamentos;

        protected ValidadorEquipamentoBase(RepositorioClientes repositorioClientes, RepositorioEquipamentos repositorioEquipamentos)
        {
            _repositorioClientes = repositorioClientes;
            _repositorioEquipamentos = repositorioEquipamentos;
        }

        public virtual void Validar(EquipamentoDto equipamentoDto)
        {
            if (!equipamentoDto.Tipo.TipoDeEquipamentoValido())
                throw new FormatoInvalido("O tipo do equipamento não é válido.");

            if (String.IsNullOrWhiteSpace(equipamentoDto.ClienteId))
                throw new FormatoInvalido("O cliente do equipamento deve ser informado.");

            if (!equipamentoDto.ClienteId.GuidValido())
                throw new FormatoInvalido("O identificador do cliente do equipamento não é válido.");

            if (_repositorioClientes.BuscarPorId(equipamentoDto.ClienteId.ParaGuid()) == null)
                throw new FormatoInvalido("O cliente do equipamento não foi encontrado.");

            if (ValidadorDeCriacao)
            {
                if (equipamentoDto.Id != Guid.Empty)
                    throw new FormatoInvalido("O identificador do equipamento não pode ser informado neste contexto.");
            }
            else
            {
                if (equipamentoDto.Id == Guid.Empty)
                    throw new FormatoInvalido("O identificador do equipamento deve ser informado.");

                var equipamentoExistente = _repositorioEquipamentos.BuscarPorId(equipamentoDto.Id);
                if (equipamentoExistente == null)
                    throw new RecursoNaoEncontrado("Equipamento não encontrado.");

                if ((int)equipamentoExistente.Tipo != equipamentoDto.Tipo)
                    throw new FormatoInvalido("O tipo do equipamento não pode ser modificado.");
            }
        }

        public virtual void Validar(String id, EquipamentoDto equipamentoDto)
        {
            if (ValidadorDeCriacao)
            {
                if (equipamentoDto.Id != Guid.Empty)
                    throw new FormatoInvalido("O identificador do equipamento não pode ser informado neste contexto.");
            }
            else
            {
                if (equipamentoDto.Id == Guid.Empty)
                    throw new FormatoInvalido("O identificador do equipamento deve ser informado.");
            }

            if (!equipamentoDto.Tipo.TipoDeEquipamentoValido())
                throw new FormatoInvalido("O tipo do equipamento não é válido.");

            if (String.IsNullOrWhiteSpace(equipamentoDto.ClienteId))
                throw new FormatoInvalido("O cliente do equipamento deve ser informado.");

            if (!equipamentoDto.ClienteId.GuidValido())
                throw new FormatoInvalido("O identificador do cliente do equipamento não é válido.");

            if (_repositorioClientes.BuscarPorId(equipamentoDto.ClienteId.ParaGuid()) == null)
                throw new FormatoInvalido("O cliente do equipamento não foi encontrado.");
        }

        public abstract bool ValidadorDeCriacao { get; }
    }
}