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
        private readonly RepositorioSites _repositorioSites;
        private readonly FabricaFatura _fabricaFatura;

        public CriadorFatura(RepositorioFaturas repositorioFaturas,
            RepositorioSites repositorioSites, 
            FabricaFatura fabricaFatura)
        {
            _repositorioFaturas = repositorioFaturas;
            _repositorioSites = repositorioSites;
            _fabricaFatura = fabricaFatura;
        }

        public Fatura Criar(Guid siteId, FaturaDto faturaDto)
        {
            var site = _repositorioSites.BuscarPorId(siteId);

            Validar(siteId, site.DiaVencimento, faturaDto);

            var fatura = _fabricaFatura.Criar(siteId, faturaDto);
            _repositorioFaturas.Inserir(fatura);
            return fatura;
        }

        public void Validar(Guid siteId, FaturaDto faturaDto)
        {
            var site = _repositorioSites.BuscarPorId(siteId);

            Validar(siteId, site.DiaVencimento, faturaDto);
        }

        private void Validar(Guid siteId, int diaVencimento, FaturaDto faturaDto)
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

            var dataAtual = DateTime.Now;
            if (faturaDto.Mes == dataAtual.Month && 
                faturaDto.Ano == dataAtual.Year &&
                dataAtual.Day < diaVencimento-10)
                throw new FormatoInvalido("Esta fatura só pode ser paga com no máximo 10 dias de antecedência.");
        }
    }
}