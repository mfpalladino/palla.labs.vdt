using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.ServicosAplicacao;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaValidadorEquipamento
    {
        public virtual IValidadorEquipamento CriarValidadorCriacao(EquipamentoDto equipamentoDto)
        {
            switch (equipamentoDto.Tipo)
            {
                case (int)TipoEquipamento.Extintor:
                    return IoC.GetInstance<ValidadorCriacaoExtintor>();
                case (int)TipoEquipamento.Mangueira:
                    return IoC.GetInstance<ValidadorCriacaoMangueira>();
                case (int)TipoEquipamento.CentralAlarme:
                    return IoC.GetInstance<ValidadorCriacaoCentralAmarme>();
                case (int)TipoEquipamento.SistemaContraIncendioEmCoifa:
                    return IoC.GetInstance<ValidadorCriacaoSistemaContraIncendioEmCoifa>();
            }

            throw new Exception("Validador não pode ser criado conforme tipo do equipamento");
        }

        public virtual IValidadorEquipamento CriarValidadorModificacao(EquipamentoDto equipamentoDto)
        {
            switch (equipamentoDto.Tipo)
            {
                case (int)TipoEquipamento.Extintor:
                    return IoC.GetInstance<ValidadorModificacaoExtintor>();
                case (int)TipoEquipamento.Mangueira:
                    return IoC.GetInstance<ValidadorModificacaoMangueira>();
                case (int)TipoEquipamento.CentralAlarme:
                    return IoC.GetInstance<ValidadorModificacaoCentralAmarme>();
                case (int)TipoEquipamento.SistemaContraIncendioEmCoifa:
                    return IoC.GetInstance<ValidadorModificacaoSistemaContraIncendioEmCoifa>();
            }

            throw new Exception("Validador não pode ser criado conforme tipo do equipamento");
        }
    }
}