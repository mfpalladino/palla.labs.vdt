using System;
using System.Collections.Generic;
using System.Linq;
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

        private static EquipamentoDto CriarSistemaContraIncendioEmCoifa(SistemaContraIncendioEmCoifa sistemaContraIncendioEmCoifa)
        {
            return new SistemaContraIncendioEmCoifaDto
            {
                Id = sistemaContraIncendioEmCoifa.Id,
                ClienteId = sistemaContraIncendioEmCoifa.ClienteId,
                Central = sistemaContraIncendioEmCoifa.Central,
                PesoCilindroCo2 = sistemaContraIncendioEmCoifa.PesoCilindroCo2,
                QuantidadeCilindroCo2 = sistemaContraIncendioEmCoifa.QuantidadeCilindroCo2,
                QuantidadeCilindroSaponificante = sistemaContraIncendioEmCoifa.QuantidadeCilindroSaponificante,
                Tipo = sistemaContraIncendioEmCoifa.Tipo
            };
        }

        private static EquipamentoDto CriarCentralAlarme(CentralAlarme centralAlarme)
        {
            return new CentralAlarmeDto
            {
                Id = centralAlarme.Id,
                ClienteId = centralAlarme.ClienteId,
                DetectorEnderecavel = centralAlarme.DetectorEnderecavel,
                Fabricante = centralAlarme.Fabricante,
                Modelo = centralAlarme.Modelo,
                QuantidadeAcionadores = centralAlarme.QuantidadeAcionadores,
                QuantidadeDetectores = centralAlarme.QuantidadeDetectores,
                QuantidadeSirenes = centralAlarme.QuantidadeSirenes,
                TipoCentralAlarme = centralAlarme.TipoCentralAlarme,
                Tipo = centralAlarme.Tipo
            };
        }

        private static EquipamentoDto CriarMangueira(Mangueira mangueira)
        {
            return new MangueiraDto
            {
                Id = mangueira.Id,
                ClienteId = mangueira.ClienteId,
                Comprimento = mangueira.Comprimento,
                Diametro = mangueira.Diametro,
                TipoMangueira = mangueira.TipoMangueira,
                Tipo = mangueira.Tipo
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
                ClienteId = extintor.ClienteId,
                NumeroCilindro = extintor.NumeroCilindro,
                Tipo = extintor.Tipo
            };
        }
    }
}