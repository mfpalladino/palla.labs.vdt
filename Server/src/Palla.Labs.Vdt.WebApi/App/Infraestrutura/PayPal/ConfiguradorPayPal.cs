using System.Collections.Generic;
using PayPal.Api;

namespace Palla.Labs.Vdt.App.Infraestrutura.PayPal
{
    public class ConfiguradorPayPal
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _urlCancelamentoPagamento;
        private readonly string _urlConfirmacaoPagamento;

        public ConfiguradorPayPal()
        {
            var config = GetConfig();
            _clientId = config["clientId"];
            _clientSecret = config["clientSecret"];
            _urlCancelamentoPagamento = config["urlCancelamentoPgto"];
            _urlConfirmacaoPagamento = config["urlConfirmacaoPagto"];
        }

        public APIContext GetApiContext(string accessToken = "")
        {
            var apiContext = new APIContext(string.IsNullOrEmpty(accessToken)
                ? GetAccessToken()
                : accessToken) { Config = GetConfig() };

            return apiContext;
        }

        public string UrlCancelamentoPagamento
        {
            get { return _urlCancelamentoPagamento; }
        }

        public string UrlConfirmacaoPagamento
        {
            get { return _urlConfirmacaoPagamento; }
        }

        private string GetAccessToken()
        {
            var accessToken = new OAuthTokenCredential(_clientId, _clientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        private static Dictionary<string, string> GetConfig()
        {
            return ConfigManager.Instance.GetProperties();
        }
    }
}