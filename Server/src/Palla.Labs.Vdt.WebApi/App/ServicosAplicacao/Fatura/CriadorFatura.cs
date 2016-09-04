using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class CriadorFatura
    {
        private readonly RepositorioFaturas _repositorioFaturas;
        private readonly FabricaFatura _fabricaFatura;

        public CriadorFatura(RepositorioFaturas repositorioFaturas, FabricaFatura fabricaFatura)
        {
            _repositorioFaturas = repositorioFaturas;
            _fabricaFatura = fabricaFatura;
        }

        public Fatura Criar(Guid siteId, FaturaDto faturaDto)
        {
            Validar(siteId, faturaDto);

            var fatura = _fabricaFatura.Criar(siteId, faturaDto);
            _repositorioFaturas.Inserir(fatura);
            return fatura;
        }

        private void Validar(Guid siteId, FaturaDto faturaDto)
        {
            if (faturaDto.Mes < 1 || faturaDto.Mes > 12)
                throw new FormatoInvalido("O mês da fatura não é válido.");

            if (faturaDto.Ano < 2016)
                throw new FormatoInvalido("O ano da fatura não é válido.");

            if (faturaDto.QuantidadeEquipamentos < 0)
                throw new FormatoInvalido("A quantidade de equipamentos não é válida.");

            if (faturaDto.QuantidadeUsuarios < 0)
                throw new FormatoInvalido("A quantidade de usuários não é válida.");

            if (faturaDto.Descontos < 0 || faturaDto.Descontos > faturaDto.Total)
                throw new FormatoInvalido("O desconto não é válido.");

            if (faturaDto.Total < 0)
                throw new FormatoInvalido("O total não é válido.");

            if (_repositorioFaturas.BuscarPorMesAno(siteId, faturaDto.Mes, faturaDto.Ano) != null)
                throw new FormatoInvalido("Esta fatura já consta em nosso sistema.");
        }
    }
}