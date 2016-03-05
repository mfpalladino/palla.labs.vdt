using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.SimpleInjector;
using Palla.Labs.Vdt.App.ServicosAplicacao;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaValidadorEquipamento
    {
        private readonly BuscadorDeInstancias _buscadorDeInstancias;

        public FabricaValidadorEquipamento(BuscadorDeInstancias buscadorDeInstancias)
        {
            _buscadorDeInstancias = buscadorDeInstancias;
        }

        public virtual IValidadorEquipamento CriarValidadorCriacao(EquipamentoDto equipamentoDto)
        {
            switch (equipamentoDto.Tipo)
            {
                case (int)TipoEquipamento.Extintor:
                    return _buscadorDeInstancias.Buscar<ValidadorCriacaoExtintor>();
                case (int)TipoEquipamento.Mangueira:
                    return _buscadorDeInstancias.Buscar<ValidadorCriacaoMangueira>();
                case (int)TipoEquipamento.CentralAlarme:
                    return _buscadorDeInstancias.Buscar<ValidadorCriacaoCentralAmarme>();
                case (int)TipoEquipamento.SistemaContraIncendioEmCoifa:
                    return _buscadorDeInstancias.Buscar<ValidadorCriacaoSistemaContraIncendioEmCoifa>();
            }

            throw new Exception("Validador não pode ser criado conforme tipo do equipamento");
        }

        public virtual IValidadorEquipamento CriarValidadorModificacao(EquipamentoDto equipamentoDto)
        {
            switch (equipamentoDto.Tipo)
            {
                case (int)TipoEquipamento.Extintor:
                    return _buscadorDeInstancias.Buscar<ValidadorModificacaoExtintor>();
                case (int)TipoEquipamento.Mangueira:
                    return _buscadorDeInstancias.Buscar<ValidadorModificacaoMangueira>();
                case (int)TipoEquipamento.CentralAlarme:
                    return _buscadorDeInstancias.Buscar<ValidadorModificacaoCentralAmarme>();
                case (int)TipoEquipamento.SistemaContraIncendioEmCoifa:
                    return _buscadorDeInstancias.Buscar<ValidadorModificacaoSistemaContraIncendioEmCoifa>();
            }

            throw new Exception("Validador não pode ser criado conforme tipo do equipamento");
        }
    }
}