namespace Palla.Labs.Vdt.App.Infraestrutura.PayPal
{
    public class ResultadoPagamentoPayPal
    {
        public string Token { get; private set; }
        public string UrlParaPagamento { get; private set; }

        public ResultadoPagamentoPayPal(string token, string urlParaPagamento)
        {
            Token = token;
            UrlParaPagamento = urlParaPagamento;
        }
    }
}