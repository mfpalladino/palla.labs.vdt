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

        public virtual Equipamento Criar(Guid siteId, EquipamentoDto equipamentoDto)
        {
            return Criar(siteId, equipamentoDto.Id, equipamentoDto);
        }

        public virtual Equipamento Criar(Guid siteId, Guid id, EquipamentoDto equipamentoDto)
        {
            var equipamento = id != Guid.Empty ? _repositorioEquipamentos.BuscarPorId(siteId, id) : null;
            var manutencoes = equipamento != null ? equipamento.Manutencoes.ToList() : new List<Manutencao>();

            switch (equipamentoDto.Tipo)
            {
                case (int)TipoEquipamento.Extintor:
                    return CriarExtintor(siteId, id, equipamentoDto as ExtintorDto, manutencoes);
                case (int)TipoEquipamento.Mangueira:
                    return CriarMangueira(siteId, id, equipamentoDto as MangueiraDto, manutencoes);
                case (int)TipoEquipamento.CentralAlarme:
                    return CriarCentralAlarme(siteId, id, equipamentoDto as CentralAlarmeDto, manutencoes);
                case (int)TipoEquipamento.SistemaContraIncendioEmCoifa:
                    return CriarSistemaContraIncendioEmCoifa(siteId, id, equipamentoDto as SistemaContraIncendioEmCoifaDto, manutencoes);
            }

            throw new Exception("Equipamento não pode ser mapeado em modelo conforme seu tipo");
        }

        private static Equipamento CriarExtintor(Guid siteId, Guid id, ExtintorDto extintorDto, IList<Manutencao> manutencoes)
        {
            return new Extintor(siteId, id, extintorDto.ClienteId.ParaGuid(), extintorDto.NumeroCilindro, extintorDto.Agente, extintorDto.Localizacao, extintorDto.FabricadoEm, manutencoes, extintorDto.EstaAtivo);
        }

        private static Equipamento CriarMangueira(Guid siteId, Guid id, MangueiraDto mangueiraDto, IList<Manutencao> manutencoes)
        {
            return new Mangueira(siteId, id, mangueiraDto.ClienteId.ParaGuid(), (TipoMangueira)mangueiraDto.TipoMangueira, (DiametroMangueira)mangueiraDto.Diametro, (ComprimentoMangueira)mangueiraDto.Comprimento, manutencoes, mangueiraDto.EstaAtivo);
        }

        private static Equipamento CriarCentralAlarme(Guid siteId, Guid id, CentralAlarmeDto centralAlarmeDto, IList<Manutencao> manutencoes)
        {
            return new CentralAlarme(siteId, id, centralAlarmeDto.ClienteId.ParaGuid(), centralAlarmeDto.Fabricante, centralAlarmeDto.Modelo, (TipoCentralAlarme)centralAlarmeDto.TipoCentralAlarme, centralAlarmeDto.QuantidadeDetectores, centralAlarmeDto.DetectorEnderecavel, centralAlarmeDto.QuantidadeAcionadores, centralAlarmeDto.QuantidadeSirenes, manutencoes, centralAlarmeDto.EstaAtivo);
        }

        private static Equipamento CriarSistemaContraIncendioEmCoifa(Guid siteId, Guid id, SistemaContraIncendioEmCoifaDto sistemaContraIncendioEmCoifaDto, IList<Manutencao> manutencoes)
        {
            return new SistemaContraIncendioEmCoifa(siteId, id, sistemaContraIncendioEmCoifaDto.ClienteId.ParaGuid(), sistemaContraIncendioEmCoifaDto.Central, sistemaContraIncendioEmCoifaDto.QuantidadeCilindroCo2, sistemaContraIncendioEmCoifaDto.PesoCilindroCo2, sistemaContraIncendioEmCoifaDto.QuantidadeCilindroSaponificante, manutencoes, sistemaContraIncendioEmCoifaDto.EstaAtivo);
        }
    }
}