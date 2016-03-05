using System;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ValidadorCriacaoCentralAmarme : ValidadorEquipamentoBase
    {
        public ValidadorCriacaoCentralAmarme(RepositorioClientes repositorioClientes, RepositorioEquipamentos repositorioEquipamentos)
            : base(repositorioClientes, repositorioEquipamentos)
        {
        }

        public override void Validar(EquipamentoDto equipamentoDto)
        {
            base.Validar(equipamentoDto);

            var equipamentoEspecifico = equipamentoDto as CentralAlarmeDto;

            if (equipamentoEspecifico == null)
                throw new Exception("N�o � poss�vel validar o equipamento (problema de convers�o).");

            if (!equipamentoEspecifico.TipoCentralAlarme.TipoCentralAlarmeValido())
                throw new FormatoInvalido("O tipo da central de alarme n�o � v�lido.");
        }

        public override bool ValidadorDeCriacao
        {
            get { return true; }
        }
    }
}