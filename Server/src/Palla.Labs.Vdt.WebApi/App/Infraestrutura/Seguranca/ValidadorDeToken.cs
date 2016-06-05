using System;
using System.Text;

namespace Palla.Labs.Vdt.App.Infraestrutura.Seguranca
{
    public class ValidadorDeToken
    {
        private readonly GeradorDeToken _geradorDeToken;
        private const int MinutosParaExpirar = 60;

        public ValidadorDeToken(GeradorDeToken geradorDeToken)
        {
            _geradorDeToken = geradorDeToken;
        }

        public bool Validar(string token, string ip, string userAgent)
        {
            var result = false;
            const short numeroDePartesDoToken = 4;

            try
            {
                var key = Encoding.UTF8.GetString(Convert.FromBase64String(token));

                var parts = key.Split(':');
                if (parts.Length == numeroDePartesDoToken)
                {
                    var siteId = parts[1];
                    var username = parts[2];
                    var ticks = long.Parse(parts[3]);
                    var timeStamp = new DateTime(ticks);

                    var expired = Math.Abs((DateTime.UtcNow - timeStamp).TotalMinutes) > MinutosParaExpirar;
                    if (!expired)
                    {
                        if (username == "teste") //todo acertar
                        {
                            const string password = "teste"; //todo acertar

                            var computedToken = _geradorDeToken.Gerar(new Guid(siteId), username, password, ip, userAgent, ticks);

                            result = token == computedToken;
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }        
    }
}