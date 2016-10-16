using Palla.Labs.Vdt.App.Dominio.Dtos;
using PayPal.Api;

namespace Palla.Labs.Vdt.App.Infraestrutura.PayPal
{
    public class IntegradorPayPal
    {
        private readonly ConfiguradorPayPal _configuradorPayPal;
        private readonly FabricaPagamentoPayPal _fabricaPagamentoPayPal;

        public IntegradorPayPal(ConfiguradorPayPal configuradorPayPal, FabricaPagamentoPayPal fabricaPagamentoPayPal)
        {
            _configuradorPayPal = configuradorPayPal;
            _fabricaPagamentoPayPal = fabricaPagamentoPayPal;
        }

        public ResultadoPagamentoPayPal CriarPagamento(string baseUrl, FaturaDto faturaDto)
        {
            var apiContext = _configuradorPayPal.GetApiContext();

            var pagamentoCriado = _fabricaPagamentoPayPal.Criar(baseUrl, faturaDto).Create(apiContext);

            return new ResultadoPagamentoPayPal(pagamentoCriado.token, pagamentoCriado.GetApprovalUrl());
        }

        public Payment ExecutarPagamento(string idPagamento, string idPagador)
        {
            var apiContext = _configuradorPayPal.GetApiContext();

            var paymentExecution = new PaymentExecution { payer_id = idPagador };
            var payment = new Payment { id = idPagamento };

            var executedPayment = payment.Execute(apiContext, paymentExecution);
            return executedPayment;
        }
    }
}