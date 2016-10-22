using System;
using System.Collections.Generic;
using System.Globalization;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using PayPal.Api;

namespace Palla.Labs.Vdt.App.Infraestrutura.PayPal
{
    public class FabricaPagamentoPayPal
    {
        public virtual Payment Criar(string urlCancelamentoPagamento, string urlConfirmacaoPagamento, FaturaDto faturaDto)
        {
            return new Payment
            {
                intent = "sale",
                payer = new Payer { payment_method = "paypal" },
                transactions = PegarListaTransacoes(faturaDto),
                redirect_urls = new RedirectUrls
                {
                    cancel_url = urlCancelamentoPagamento,
                    return_url = urlConfirmacaoPagamento
                }
            };
        }

        private static List<Transaction> PegarListaTransacoes(FaturaDto faturaDto)
        {
            var transactionList = new List<Transaction>
            {
                new Transaction
                {
                    description = "Pagamento fatura SCEI: " + faturaDto.MesAnoComoString,
                    invoice_number = PegarNumeroRandomicoParaPagamento(),
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
                                name = "Usuários mantidos pelo SCEI",
                                currency = "BRL",
                                price = faturaDto.ValorPorUsuario.ToString(CultureInfo.InvariantCulture),
                                quantity = faturaDto.QuantidadeUsuarios.ToString(CultureInfo.InvariantCulture),
                                sku = "#1-usuários"
                            },
                            new Item
                            {
                                name = "Equipamentos mantidos pelo SCEI",
                                currency = "BRL",
                                price = faturaDto.ValorPorEquipamento.ToString(CultureInfo.InvariantCulture),
                                quantity = faturaDto.QuantidadeEquipamentos.ToString(CultureInfo.InvariantCulture),
                                sku = "#2-equipamentos"
                            }
                        }
                    }
                }
            };

            return transactionList;
        }

        private static string PegarNumeroRandomicoParaPagamento()
        {
            return new Random().Next(999999).ToString();
        }
    }
}