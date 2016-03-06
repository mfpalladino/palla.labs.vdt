using System;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ModificadorEquipamento
    {
        private readonly RepositorioEquipamentos _repositorioEquipamentos;
        private readonly FabricaEquipamento _fabricaEquipamento;
        private readonly FabricaValidadorEquipamento _fabricaValidadorEquipamento;

        public ModificadorEquipamento(RepositorioEquipamentos repositorioEquipamentos, FabricaEquipamento fabricaEquipamento, FabricaValidadorEquipamento fabricaValidadorEquipamento)
        {
            _repositorioEquipamentos = repositorioEquipamentos;
            _fabricaEquipamento = fabricaEquipamento;
            _fabricaValidadorEquipamento = fabricaValidadorEquipamento;
        }

        public void Modificar(string id, EquipamentoDto equipamentoDto)
        {
            equipamentoDto.Id = id.GuidValido() ? id.ParaGuid() : Guid.Empty;

            _fabricaValidadorEquipamento
                .CriarValidadorModificacao(equipamentoDto)
                .Validar(equipamentoDto);

            var equipamento = _fabricaEquipamento.Criar(equipamentoDto.Id, equipamentoDto);
            _repositorioEquipamentos.Editar(equipamento);
        }
    }
}