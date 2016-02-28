using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaEquipamento
    {
        public virtual Equipamento Criar(EquipamentoDto equipamentoDto)
        {
            return Criar(equipamentoDto.Id, equipamentoDto);
        }

        public virtual Equipamento Criar(Guid id, EquipamentoDto equipamentoDto)
        {
            switch (equipamentoDto.Tipo)
            {
                case TipoEquipamento.Extintor:
                    return CriarExtintor(id, equipamentoDto as ExtintorDto);
                case TipoEquipamento.Mangueira:
                    return CriarMangueira(id, equipamentoDto as MangueiraDto);
                case TipoEquipamento.CentralAlarme:
                    return CriarCentralAlarme(id, equipamentoDto as CentralAlarmeDto);
                case TipoEquipamento.SistemaContraIncendioEmCoifa:
                    return CriarSistemaContraIncendioEmCoifa(id, equipamentoDto as SistemaContraIncendioEmCoifaDto);
            }

            throw new Exception("Equipamento não pode ser mapeado em modelo conforme seu tipo");
        }

        private static Equipamento CriarExtintor(Guid id, ExtintorDto extintorDto)
        {
            return new Extintor(id, extintorDto.NumeroCilindro, extintorDto.Agente, extintorDto.Localizacao, extintorDto.FabricadoEm.APartirDeUnixTime(), new List<Manutencao>());
        }

        private static Equipamento CriarMangueira(Guid id, MangueiraDto mangueiraDto)
        {
            throw new NotImplementedException();
        }

        private static Equipamento CriarCentralAlarme(Guid id, CentralAlarmeDto centralAlarmeDto)
        {
            throw new NotImplementedException();
        }

        private static Equipamento CriarSistemaContraIncendioEmCoifa(Guid id, SistemaContraIncendioEmCoifaDto sistemaContraIncendioEmCoifaDto)
        {
            throw new NotImplementedException();
        }
    }
}