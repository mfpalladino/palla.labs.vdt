using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class CriadorEquipamento
    {
        private readonly RepositorioEquipamentos _repositorioEquipamentos;
        private readonly FabricaEquipamento _fabricaEquipamento;
        private readonly FabricaValidadorEquipamento _fabricaValidadorEquipamento;

        public CriadorEquipamento(RepositorioEquipamentos repositorioEquipamentos, FabricaEquipamento fabricaEquipamento, FabricaValidadorEquipamento fabricaValidadorEquipamento)
        {
            _repositorioEquipamentos = repositorioEquipamentos;
            _fabricaEquipamento = fabricaEquipamento;
            _fabricaValidadorEquipamento = fabricaValidadorEquipamento;
        }

        public Equipamento Criar(Guid siteId, EquipamentoDto equipamentoDto)
        {
            _fabricaValidadorEquipamento
                .CriarValidadorCriacao(equipamentoDto)
                .Validar(siteId, equipamentoDto);

            var equipamento = _fabricaEquipamento.Criar(siteId, Guid.NewGuid(), equipamentoDto);
            _repositorioEquipamentos.Inserir(equipamento);
            return equipamento;
        }
    }
}