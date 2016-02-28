using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
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

        public CriadorEquipamento(RepositorioEquipamentos repositorioEquipamentos, FabricaEquipamento fabricaEquipamento)
        {
            _repositorioEquipamentos = repositorioEquipamentos;
            _fabricaEquipamento = fabricaEquipamento;
        }

        public Equipamento Criar(EquipamentoDto equipamentoDto)
        {
            Validar(equipamentoDto);

            var equipamento = _fabricaEquipamento.Criar(Guid.NewGuid(), equipamentoDto);
            _repositorioEquipamentos.Inserir(equipamento);
            return equipamento;
        }

        private static void Validar(EquipamentoDto equipamentoDto)
        {
            if (equipamentoDto.Id != Guid.Empty)
                throw new FormatoInvalido("O identificador de equipamento não deve ser informado neste contexto.");
        }
    }
}