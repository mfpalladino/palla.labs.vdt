using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ValidadorCriacaoSistemaContraIncendioEmCoifa : ValidadorEquipamentoBase
    {
        public override void Validar(EquipamentoDto equipamentoDto)
        {
            base.Validar(equipamentoDto);

            var equipamentoEspecifico = equipamentoDto as SistemaContraIncendioEmCoifaDto;

            if (equipamentoEspecifico == null)
                throw new Exception("Não é possível validar o equipamento (problema de conversão).");
       }

        public override bool EValidadorDeCriacao
        {
            get { return true; }
        }

        public ValidadorCriacaoSistemaContraIncendioEmCoifa(RepositorioClientes repositorioClientes) : base(repositorioClientes)
        {
        }
    }
}