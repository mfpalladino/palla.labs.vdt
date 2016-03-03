using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ValidadorCriacaoMangueira : ValidadorEquipamentoBase
    {
        public override void Validar(EquipamentoDto equipamentoDto)
        {
            base.Validar(equipamentoDto);

            var equipamentoEspecifico = equipamentoDto as MangueiraDto;

            if (equipamentoEspecifico == null)
                throw new Exception("Não é possível validar o equipamento (problema de conversão).");

            ValidarAtributosMangueira(equipamentoEspecifico.Comprimento,
                equipamentoEspecifico.Diametro,
                equipamentoEspecifico.TipoMangueira);
        }

        public override bool EValidadorDeCriacao
        {
            get { return true; }
        }

        public ValidadorCriacaoMangueira(RepositorioClientes repositorioClientes) : base(repositorioClientes)
        {
        }
    }
}