using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ValidadorCriacaoSistemaContraIncendioEmCoifa : ValidadorEquipamentoBase
    {
        public ValidadorCriacaoSistemaContraIncendioEmCoifa(RepositorioClientes repositorioClientes, RepositorioEquipamentos repositorioEquipamentos)
            : base(repositorioClientes, repositorioEquipamentos)
        {
        }

        public override void Validar(EquipamentoDto equipamentoDto)
        {
            base.Validar(equipamentoDto);

            var equipamentoEspecifico = equipamentoDto as SistemaContraIncendioEmCoifaDto;

            if (equipamentoEspecifico == null)
                throw new Exception("N�o � poss�vel validar o equipamento (problema de convers�o).");
       }

        public override bool ValidadorDeCriacao
        {
            get { return true; }
        }
    }
}