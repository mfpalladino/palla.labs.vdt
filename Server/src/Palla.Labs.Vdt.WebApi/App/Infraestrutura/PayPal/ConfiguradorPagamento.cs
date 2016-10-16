using System.Collections.Generic;
using PayPal.Api;

namespace Palla.Labs.Vdt.App.Infraestrutura.PayPal
{
    public static class ConfiguradorPagamento
    {
        public static readonly string ClientId;
        public static readonly string ClientSecret;

        static ConfiguradorPagamento()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }

        public static APIContext GetApiContext(string accessToken = "")
        {
            var apiContext = new APIContext(string.IsNullOrEmpty(accessToken)
                ? GetAccessToken()
                : accessToken) { Config = GetConfig() };

            return apiContext;
        }

        private static string GetAccessToken()
        {
            var accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        public static Dictionary<string, string> GetConfig()
        {
            // ConfigManager.Instance.GetProperties(); // it doesn't work on ASPNET 5
            return new Dictionary<string, string> {
                { "clientId", "" }, //todo
                { "clientSecret", "" } //todo
            };
        }
    }
}