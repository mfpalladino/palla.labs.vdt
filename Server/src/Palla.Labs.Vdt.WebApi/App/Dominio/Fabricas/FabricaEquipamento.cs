using System;
using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaEquipamento
    {
        private readonly RepositorioEquipamentos _repositorioEquipamentos;

        public FabricaEquipamento(RepositorioEquipamentos repositorioEquipamentos)
        {
            _repositorioEquipamentos = repositorioEquipamentos;
        }

        public virtual Equipamento Criar(EquipamentoDto equipamentoDto)
        {
            return Criar(equipamentoDto.Id, equipamentoDto);
        }

        public virtual Equipamento Criar(Guid id, EquipamentoDto equipamentoDto)
        {
            var equipamento = id != Guid.Empty ? _repositorioEquipamentos.BuscarPorId(id) : null;
            var manutencoes = equipamento != null ? equipamento.Manutencoes.ToList() : new List<Manutencao>();

            switch (equipamentoDto.Tipo)
            {
                case (int)TipoEquipamento.Extintor:
                    return CriarExtintor(id, equipamentoDto as ExtintorDto, manutencoes);
                case (int)TipoEquipamento.Mangueira:
                    return CriarMangueira(id, equipamentoDto as MangueiraDto, manutencoes);
                case (int)TipoEquipamento.CentralAlarme:
                    return CriarCentralAlarme(id, equipamentoDto as CentralAlarmeDto, manutencoes);
                case (int)TipoEquipamento.SistemaContraIncendioEmCoifa:
                    return CriarSistemaContraIncendioEmCoifa(id, equipamentoDto as SistemaContraIncendioEmCoifaDto, manutencoes);
            }

            throw new Exception("Equipamento não pode ser mapeado em modelo conforme seu tipo");
        }

        private static Equipamento CriarExtintor(Guid id, ExtintorDto extintorDto, IList<Manutencao> manutencoes)
        {
            return new Extintor(id, extintorDto.ClienteId.ParaGuid(), extintorDto.NumeroCilindro, extintorDto.Agente, extintorDto.Localizacao, extintorDto.FabricadoEm, manutencoes);
        }

        private static Equipamento CriarMangueira(Guid id, MangueiraDto mangueiraDto, IList<Manutencao> manutencoes)
        {
            return new Mangueira(id, mangueiraDto.ClienteId.ParaGuid(), (TipoMangueira)mangueiraDto.TipoMangueira, (DiametroMangueira)mangueiraDto.Diametro, (ComprimentoMangueira)mangueiraDto.Comprimento, manutencoes);
        }

        private static Equipamento CriarCentralAlarme(Guid id, CentralAlarmeDto centralAlarmeDto, IList<Manutencao> manutencoes)
        {
            return new CentralAlarme(id, centralAlarmeDto.ClienteId.ParaGuid(), centralAlarmeDto.Fabricante, centralAlarmeDto.Modelo, (TipoCentralAlarme)centralAlarmeDto.TipoCentralAlarme, centralAlarmeDto.QuantidadeDetectores, centralAlarmeDto.DetectorEnderecavel, centralAlarmeDto.QuantidadeAcionadores, centralAlarmeDto.QuantidadeSirenes, manutencoes);
        }

        private static Equipamento CriarSistemaContraIncendioEmCoifa(Guid id, SistemaContraIncendioEmCoifaDto sistemaContraIncendioEmCoifaDto, IList<Manutencao> manutencoes)
        {
            return new SistemaContraIncendioEmCoifa(id, sistemaContraIncendioEmCoifaDto.ClienteId.ParaGuid(), sistemaContraIncendioEmCoifaDto.Central, sistemaContraIncendioEmCoifaDto.QuantidadeCilindroCo2, sistemaContraIncendioEmCoifaDto.PesoCilindroCo2, sistemaContraIncendioEmCoifaDto.QuantidadeCilindroSaponificante, manutencoes);
        }
    }
}