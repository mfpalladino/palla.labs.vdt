using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Dominio.Modelos;
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

        public EquipamentoDto Localizar(Guid siteId, string id, long? referenciaSituacao)
        {
            Validar(siteId, id);
            return _fabricaEquipamentoDto.Criar(siteId, _repositorioEquipamentos.BuscarPorId(siteId, new Guid(id)), referenciaSituacao);
        }

        public IEnumerable<EquipamentoDto> Localizar(Guid siteId, long? referenciaSituacao, SituacaoManutencao situacaoManutencao)
        {
            return _fabricaEquipamentoDto.Criar(siteId, _repositorioEquipamentos.Buscar(siteId), referenciaSituacao, situacaoManutencao);
        }

        public IEnumerable<EquipamentoDto> LocalizarPorGrupo(Guid siteId, string grupoId, SituacaoManutencao situacaoManutencao)
        {
            ValidarIdGrupo(grupoId);
            return _fabricaEquipamentoDto.Criar(siteId, _repositorioEquipamentos.BuscarPorGrupo(siteId, grupoId.ParaGuid()), situacaoManutencao);
        }

        public IEnumerable<EquipamentoDto> LocalizarPorCliente(Guid siteId, string clienteId)
        {
            ValidarIdCliente(clienteId);
            return _fabricaEquipamentoDto.Criar(siteId, _repositorioEquipamentos.BuscarPorCliente(siteId, clienteId.ParaGuid()));
        }

        public IEnumerable<ManutencaoDto> LocalizarManutencoes(Guid siteId, string id)
        {
            Validar(siteId, id);
            return _fabricaManutencaoDto.Criar(_repositorioEquipamentos.BuscarPorId(siteId, new Guid(id)).Manutencoes);
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

        private void Validar(Guid siteId, string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de equipamento informado não é válido.");

            if (_repositorioEquipamentos.BuscarPorId(siteId, new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Equipamento não encontrado");
        }
    }
}