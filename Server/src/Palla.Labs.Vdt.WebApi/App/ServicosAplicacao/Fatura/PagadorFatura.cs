using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Infraestrutura.PayPal;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class PagadorFatura
    {
        private readonly CriadorFatura _criadorFatura;
        private readonly IntegradorPayPal _integradorPayPal;
        private readonly CachePayPal _cachePayPal;

        public PagadorFatura(CriadorFatura criadorFatura, IntegradorPayPal integradorPayPal, CachePayPal cachePayPal)
        {
            _criadorFatura = criadorFatura;
            _integradorPayPal = integradorPayPal;
            _cachePayPal = cachePayPal;
        }

        public void Pagar(Guid idSite, PagamentoConfirmadoDto pagamentoConfirmadoDto)
        {
            _integradorPayPal.ConfirmarPagamento(idSite, pagamentoConfirmadoDto.Token, pagamentoConfirmadoDto.PagamentoId, pagamentoConfirmadoDto.PagadorId);

            _criadorFatura.Criar(idSite, _cachePayPal.Recuperar(idSite, pagamentoConfirmadoDto.Token));

            _cachePayPal.Remover(idSite, pagamentoConfirmadoDto.Token);
        }
    }
}