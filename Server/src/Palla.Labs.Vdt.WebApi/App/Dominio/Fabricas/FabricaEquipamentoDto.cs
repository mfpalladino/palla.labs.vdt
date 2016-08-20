using System;
using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Dominio.Servicos;
using Palla.Labs.Vdt.App.Infraestrutura.Json;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaEquipamentoDto
    {
        private readonly ConversorDeJson _conversorDeJson;
        private readonly CalculadoraSituacaoManutencao _calculadoraSituacaoManutencao;
        private readonly RepositorioClientes _repositorioClientes;

        public FabricaEquipamentoDto(ConversorDeJson conversorDeJson, CalculadoraSituacaoManutencao calculadoraSituacaoManutencao, RepositorioClientes repositorioClientes)
        {
            _conversorDeJson = conversorDeJson;
            _calculadoraSituacaoManutencao = calculadoraSituacaoManutencao;
            _repositorioClientes = repositorioClientes;
        }

        public virtual IEnumerable<EquipamentoDto> Criar(Guid siteId, IEnumerable<Equipamento> equipamentos)
        {
            return Criar(siteId, equipamentos, DateTime.Now.ParaUnixTime(), SituacaoManutencao.Todos);
        }

        public virtual IEnumerable<EquipamentoDto> Criar(Guid siteId, IEnumerable<Equipamento> equipamentos, SituacaoManutencao situacaoManutencao)
        {
            return Criar(siteId, equipamentos, DateTime.Now.ParaUnixTime(), situacaoManutencao);
        }

        public virtual IEnumerable<EquipamentoDto> Criar(Guid siteId, IEnumerable<Equipamento> equipamentos, long? dataReferenciaSituacao, SituacaoManutencao situacaoManutencao)
        {
            var resultado = equipamentos.Select(x => Criar(siteId, x, dataReferenciaSituacao != null && dataReferenciaSituacao > -1 ? dataReferenciaSituacao.Value : DateTime.Now.ParaUnixTime()));
            return situacaoManutencao == SituacaoManutencao.Todos ? resultado : resultado.Where(x=>x.SituacaoManutencao == (int)situacaoManutencao);
        }

        public virtual EquipamentoDto Criar(Guid siteId, Equipamento equipamento)
        {
            return Criar(siteId, equipamento, DateTime.Now.ParaUnixTime());
        }

        public virtual EquipamentoDto Criar(Guid siteId, Equipamento equipamento, long? dataReferenciaSituacao)
        {
            EquipamentoDto equipamentoResultante;
            switch (equipamento.Tipo)
            {
                case TipoEquipamento.Extintor:
                    equipamentoResultante = CriarExtintor(equipamento as Extintor);
                    break;
                case TipoEquipamento.Mangueira:
                    equipamentoResultante = CriarMangueira(equipamento as Mangueira);
                    break;
                case TipoEquipamento.CentralAlarme:
                    equipamentoResultante = CriarCentralAlarme(equipamento as CentralAlarme);
                    break;
                case TipoEquipamento.SistemaContraIncendioEmCoifa:
                    equipamentoResultante = CriarSistemaContraIncendioEmCoifa(equipamento as SistemaContraIncendioEmCoifa);
                    break;
                default:
                    throw new Exception("Equipamento não pode ser mapeado em um dto conforme seu tipo");
            }

            var cliente = _repositorioClientes.BuscarPorId(siteId, equipamentoResultante.ClienteId.ParaGuid());
            equipamentoResultante.ClienteNome = cliente != null ? cliente.Nome : string.Empty;
            equipamentoResultante.PartesParaManutencao = equipamento.ParametrosManutencao.Partes.Select(x => x.Nome).ToArray();

            equipamentoResultante.SituacaoManutencao = 
                (int)_calculadoraSituacaoManutencao.Calcular(equipamento, dataReferenciaSituacao ?? DateTime.Now.ParaUnixTime());

            return equipamentoResultante;
        }

        public virtual EquipamentoDto Criar(int tipo, string json)
        {
            switch (tipo)
            {
                case (int)TipoEquipamento.Extintor:
                    return _conversorDeJson.Deserializar<ExtintorDto>(json);
                case (int)TipoEquipamento.Mangueira:
                    return _conversorDeJson.Deserializar<MangueiraDto>(json);
                case (int)TipoEquipamento.CentralAlarme:
                    return _conversorDeJson.Deserializar<CentralAlarmeDto>(json);
                case (int)TipoEquipamento.SistemaContraIncendioEmCoifa:
                    return _conversorDeJson.Deserializar<SistemaContraIncendioEmCoifaDto>(json);
            }

            throw new Exception("Equipamento não pode ser mapeado em um dto conforme seu tipo");
        }

        private static EquipamentoDto CriarSistemaContraIncendioEmCoifa(SistemaContraIncendioEmCoifa sistemaContraIncendioEmCoifa)
        {
            return new SistemaContraIncendioEmCoifaDto
            {
                Id = sistemaContraIncendioEmCoifa.Id,
                ClienteId = sistemaContraIncendioEmCoifa.ClienteId.ToString(),
                Central = sistemaContraIncendioEmCoifa.Central,
                PesoCilindroCo2 = sistemaContraIncendioEmCoifa.PesoCilindroCo2,
                QuantidadeCilindroCo2 = sistemaContraIncendioEmCoifa.QuantidadeCilindroCo2,
                QuantidadeCilindroSaponificante = sistemaContraIncendioEmCoifa.QuantidadeCilindroSaponificante,
                Tipo = (int)sistemaContraIncendioEmCoifa.Tipo,
                Nome = sistemaContraIncendioEmCoifa.Nome,
                EstaAtivo = sistemaContraIncendioEmCoifa.EstaAtivo
            };
        }

        private static EquipamentoDto CriarCentralAlarme(CentralAlarme centralAlarme)
        {
            return new CentralAlarmeDto
            {
                Id = centralAlarme.Id,
                ClienteId = centralAlarme.ClienteId.ToString(),
                DetectorEnderecavel = centralAlarme.DetectorEnderecavel,
                Fabricante = centralAlarme.Fabricante,
                Modelo = centralAlarme.Modelo,
                QuantidadeAcionadores = centralAlarme.QuantidadeAcionadores,
                QuantidadeDetectores = centralAlarme.QuantidadeDetectores,
                QuantidadeSirenes = centralAlarme.QuantidadeSirenes,
                TipoCentralAlarme = (int)centralAlarme.TipoCentralAlarme,
                Tipo = (int)centralAlarme.Tipo,
                Nome = centralAlarme.Nome,
                EstaAtivo = centralAlarme.EstaAtivo
            };
        }

        private static EquipamentoDto CriarMangueira(Mangueira mangueira)
        {
            return new MangueiraDto
            {
                Id = mangueira.Id,
                ClienteId = mangueira.ClienteId.ToString(),
                Comprimento = (int)mangueira.Comprimento,
                Diametro = (int)mangueira.Diametro,
                TipoMangueira = (int)mangueira.TipoMangueira,
                Tipo = (int)mangueira.Tipo,
                Nome = mangueira.Nome,
                EstaAtivo = mangueira.EstaAtivo
            };
        }

        private static EquipamentoDto CriarExtintor(Extintor extintor)
        {
            return new ExtintorDto
            {
                Id = extintor.Id,
                Agente = extintor.Agente,
                FabricadoEm = extintor.FabricadoEm,
                Localizacao = extintor.Localizacao,
                ClienteId = extintor.ClienteId.ToString(),
                NumeroCilindro = extintor.NumeroCilindro,
                Tipo = (int)extintor.Tipo,
                Nome = extintor.Nome,
                EstaAtivo = extintor.EstaAtivo
            };
        }
    }
}