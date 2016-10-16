using System;
using System.Collections.Generic;
using System.Globalization;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using PayPal.Api;

namespace Palla.Labs.Vdt.App.Infraestrutura.PayPal
{
    public class CriadorPagamento
    {
        public string CriarPagamento(FaturaDto faturaDto)
        {
            var apiContext = ConfiguradorPagamento.GetApiContext();

            var payment = new Payment
            {
                intent = "sale",
                payer = new Payer { payment_method = "paypal" },
                transactions = PegarListaTransacoes(faturaDto),
                redirect_urls = PegarUrls()
            };

            var createdPayment = payment.Create(apiContext);

            return createdPayment.GetApprovalUrl();
        }

        private static List<Transaction> PegarListaTransacoes(FaturaDto faturaDto)
        {
            var transactionList = new List<Transaction>
            {
                new Transaction
                {
                    description = "Pagamento fatura SCEI: " + faturaDto.MesAnoComoString,
                    invoice_number = PegarNumeroPagamento(),
                    amount = new Amount
                    {
                        currency = "BRL",
                        total = faturaDto.Total.ToString(CultureInfo.InvariantCulture),
                        details = new Details
                        {
                            tax = "0",
                            shipping = "0",
                            subtotal = faturaDto.Total.ToString(CultureInfo.InvariantCulture)
                        }
                    },
                    item_list = new ItemList
                    {
                        items = new List<Item>
                        {
                            new Item
                            {
                                name = "Usuários",
                                currency = "BRL",
                                price = faturaDto.ValorPorUsuario.ToString(CultureInfo.InvariantCulture),
                                quantity = faturaDto.QuantidadeUsuarios.ToString(CultureInfo.InvariantCulture),
                                sku = "sku"
                            },
                            new Item
                            {
                                name = "Equipamentos",
                                currency = "BRL",
                                price = faturaDto.ValorPorEquipamento.ToString(CultureInfo.InvariantCulture),
                                quantity = faturaDto.QuantidadeEquipamentos.ToString(CultureInfo.InvariantCulture),
                                sku = "sku"
                            }
                        }
                    }
                }
            };

            return transactionList;
        }

        private static RedirectUrls PegarUrls()
        {
            return new RedirectUrls
            {
                cancel_url = "/Fatura/PagamentoCancelado",
                return_url = "/Fatura/PagamentoEfetuado"
            };
        }

        public Payment ExecutarPagamento(string idPagamento, string idPagador)
        {
            var apiContext = ConfiguradorPagamento.GetApiContext();

            var paymentExecution = new PaymentExecution { payer_id = idPagador };
            var payment = new Payment { id = idPagamento };

            var executedPayment = payment.Execute(apiContext, paymentExecution);
            return executedPayment;
        }

        private static string PegarNumeroPagamento()
        {
            return new Random().Next(999999).ToString();
        }
    }
}