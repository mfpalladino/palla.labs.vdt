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
    public class LocalizadorEquipamento
    {
        private readonly RepositorioEquipamentos _repositorioEquipamentos;
        private readonly FabricaEquipamentoDto _fabricaEquipamentoDto;
        private readonly FabricaManutencaoDto _fabricaManutencaoDto;

        public LocalizadorEquipamento(RepositorioEquipamentos repositorioEquipamentos, FabricaEquipamentoDto fabricaEquipamentoDto, FabricaManutencaoDto fabricaManutencaoDto)
        {
            _repositorioEquipamentos = repositorioEquipamentos;
            _fabricaEquipamentoDto = fabricaEquipamentoDto;
            _fabricaManutencaoDto = fabricaManutencaoDto;
        }

        public EquipamentoDto Localizar(string id, long? referenciaSituacao)
        {
            Validar(id);
            return _fabricaEquipamentoDto.Criar(_repositorioEquipamentos.BuscarPorId(new Guid(id)), referenciaSituacao);
        }

        public IEnumerable<EquipamentoDto> Localizar(long? referenciaSituacao)
        {
            return _fabricaEquipamentoDto.Criar(_repositorioEquipamentos.Buscar(), referenciaSituacao);
        }

        public IEnumerable<EquipamentoDto> LocalizarPorGrupo(string grupoId)
        {
            ValidarIdGrupo(grupoId);
            return _fabricaEquipamentoDto.Criar(_repositorioEquipamentos.BuscarPorGrupo(grupoId.ParaGuid()), null);
        }

        public IEnumerable<EquipamentoDto> LocalizarPorCliente(string clienteId)
        {
            ValidarIdCliente(clienteId);
            return _fabricaEquipamentoDto.Criar(_repositorioEquipamentos.BuscarPorCliente(clienteId.ParaGuid()), null);
        }

        public IEnumerable<ManutencaoDto> LocalizarManutencoes(string id)
        {
            Validar(id);
            return _fabricaManutencaoDto.Criar(_repositorioEquipamentos.BuscarPorId(new Guid(id)).Manutencoes);
        }

        private void ValidarIdGrupo(string grupoId)
        {
            if (!grupoId.GuidValido())
                throw new FormatoInvalido("O identificador do grupo informado não é válido.");
        }

        private void ValidarIdCliente(string clienteId)
        {
            if (!clienteId.GuidValido())
                throw new FormatoInvalido("O identificador do cliente informado não é válido.");
        }

        private void Validar(string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de equipamento informado não é válido.");

            if (_repositorioEquipamentos.BuscarPorId(new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Equipamento não encontrado");
        }
    }
}