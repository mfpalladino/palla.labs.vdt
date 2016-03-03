using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaEquipamentoDto
    {
        public virtual IEnumerable<EquipamentoDto> Criar(IEnumerable<Equipamento> equipamentos)
        {
            return equipamentos.Select(Criar);
        }

        public virtual EquipamentoDto Criar(Equipamento equipamento)
        {
            switch (equipamento.Tipo)
            {
                case TipoEquipamento.Extintor:
                    return CriarExtintor(equipamento as Extintor);
                case TipoEquipamento.Mangueira:
                    return CriarMangueira(equipamento as Mangueira);
                case TipoEquipamento.CentralAlarme:
                    return CriarCentralAlarme(equipamento as CentralAlarme);
                case TipoEquipamento.SistemaContraIncendioEmCoifa:
                    return CriarSistemaContraIncendioEmCoifa(equipamento as SistemaContraIncendioEmCoifa);
            }

            throw new Exception("Equipamento não pode ser mapeado em um dto conforme seu tipo");
        }

        public virtual EquipamentoDto Criar(int tipo, string json)
        {
            switch (tipo)
            {
                case (int)TipoEquipamento.Extintor:
                    return JsonConvert.DeserializeObject<ExtintorDto>(json);
                case (int)TipoEquipamento.Mangueira:
                    return JsonConvert.DeserializeObject<MangueiraDto>(json);
                case (int)TipoEquipamento.CentralAlarme:
                    return JsonConvert.DeserializeObject<CentralAlarmeDto>(json);
                case (int)TipoEquipamento.SistemaContraIncendioEmCoifa:
                    return JsonConvert.DeserializeObject<SistemaContraIncendioEmCoifaDto>(json);
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
                Tipo = (int)sistemaContraIncendioEmCoifa.Tipo
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
                Tipo = (int)centralAlarme.Tipo
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
                Tipo = (int)mangueira.Tipo
            };
        }

        private static EquipamentoDto CriarExtintor(Extintor extintor)
        {
            return new ExtintorDto
            {
                Id = extintor.Id,
                Agente = extintor.Agente,
                FabricadoEm = extintor.FabricadoEm.ParaUnixTime(),
                Localizacao = extintor.Localizacao,
                ClienteId = extintor.ClienteId.ToString(),
                NumeroCilindro = extintor.NumeroCilindro,
                Tipo = (int)extintor.Tipo
            };
        }
    }
}