using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using PayPal.Api;

namespace Palla.Labs.Vdt.App.Infraestrutura.PayPal
{
    public class IntegradorPayPal
    {
        private readonly ConfiguradorPayPal _configuradorPayPal;
        private readonly FabricaPagamentoPayPal _fabricaPagamentoPayPal;
        private readonly CachePayPal _cachePayPal;

        public IntegradorPayPal(ConfiguradorPayPal configuradorPayPal, 
            FabricaPagamentoPayPal fabricaPagamentoPayPal,
            CachePayPal cachePayPal)
        {
            _configuradorPayPal = configuradorPayPal;
            _fabricaPagamentoPayPal = fabricaPagamentoPayPal;
            _cachePayPal = cachePayPal;
        }

        public ResultadoPagamentoPayPal CriarPagamento(Guid siteId, FaturaDto faturaDto)
        {
            var apiContext = _configuradorPayPal.GetApiContext();

            var pagamentoCriado = _fabricaPagamentoPayPal.Criar(_configuradorPayPal.UrlCancelamentoPagamento,
                _configuradorPayPal.UrlConfirmacaoPagamento, faturaDto).Create(apiContext);

            _cachePayPal.Adicionar(siteId, pagamentoCriado.token, faturaDto);

            return new ResultadoPagamentoPayPal(pagamentoCriado.token, pagamentoCriado.GetApprovalUrl());
        }

        public void CancelarPagamento(Guid siteId, string token)
        {
            _cachePayPal.Remover(siteId, token);
        }

        public Payment ConfirmarPagamento(Guid siteId, string token, string idPagamento, string idPagador)
        {
            var apiContext = _configuradorPayPal.GetApiContext();

            var paymentExecution = new PaymentExecution { payer_id = idPagador };
            var payment = new Payment { id = idPagamento };

            var executedPayment = payment.Execute(apiContext, paymentExecution);

            return executedPayment;
        }
    }
}