using System;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ValidadorCriacaoMangueira : ValidadorEquipamentoBase
    {
        public ValidadorCriacaoMangueira(RepositorioClientes repositorioClientes, RepositorioEquipamentos repositorioEquipamentos)
            : base(repositorioClientes, repositorioEquipamentos)
        {
        }

        public override void Validar(Guid siteId, EquipamentoDto equipamentoDto)
        {
            base.Validar(siteId, equipamentoDto);

            var equipamentoEspecifico = equipamentoDto as MangueiraDto;

            if (equipamentoEspecifico == null)
                throw new Exception("Não é possível validar o equipamento (problema de conversão).");

            if (!equipamentoEspecifico.Comprimento.ComprimentoMangueiraValido())
                throw new FormatoInvalido("O comprimento da mangueira não é válido.");

            if (!equipamentoEspecifico.Diametro.DiametroMangueiraValido())
                throw new FormatoInvalido("O diâmetro da mangueira não é válido.");

            if (!equipamentoEspecifico.TipoMangueira.TipoMangueiraValido())
                throw new FormatoInvalido("O tipo da mangueira não é válido.");
        }

        public override bool ValidadorDeCriacao
        {
            get { return true; }
        }
    }
}