using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class LocalizadorFatura
    {
        private readonly RepositorioFaturas _repositorioFaturas;
        private readonly FabricaFatura _fabricaFatura;
        private readonly FabricaFaturaDto _fabricaFaturaDto;

        public LocalizadorFatura(RepositorioFaturas repositorioFaturas, FabricaFatura fabricaFatura, FabricaFaturaDto fabricaFaturaDto)
        {
            _repositorioFaturas = repositorioFaturas;
            _fabricaFatura = fabricaFatura;
            _fabricaFaturaDto = fabricaFaturaDto;
        }

        public FaturaDto Localizar(Guid siteId, string id)
        {
            Validar(siteId, id);
            return _fabricaFaturaDto.Criar(_repositorioFaturas.BuscarPorId(siteId, new Guid(id)));
        }

        public IEnumerable<FaturaDto> Localizar(Guid siteId)
        {
            return _fabricaFaturaDto.Criar(_repositorioFaturas.Buscar(siteId));
        }

        public FaturaDto LocalizarAtual(Guid siteId)
        {
            return _fabricaFaturaDto.Criar(_fabricaFatura.CriarAtual(siteId));
        }


        private void Validar(Guid siteId, string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador da fatura informado não é válido.");

            if (_repositorioFaturas.BuscarPorId(siteId, new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Fatura não encontrada");
        }
    }
}