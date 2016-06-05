using System;
using System.Security.Cryptography;
using System.Text;

namespace Palla.Labs.Vdt.App.Infraestrutura.Seguranca
{
    public class GeradorDeToken
    {
        private readonly ConfigSeguranca _configSeguranca;
        private readonly GeradorDeSenha _geradorDeSenha;

        public GeradorDeToken(ConfigSeguranca configSeguranca, GeradorDeSenha geradorDeSenha)
        {
            _configSeguranca = configSeguranca;
            _geradorDeSenha = geradorDeSenha;
        }

        public string Gerar(Guid siteId, string nomeUsuario, string senhaUsuario, string ip, string userAgent, long ticks)
        {
            var hash = string.Join(":", siteId, nomeUsuario, ip, userAgent, ticks.ToString());
            string hashLeft;
            string hashRight;

            using (var hmac = HMAC.Create(_configSeguranca.AlgoritmoParaCriptografia))
            {
                hmac.Key = Encoding.UTF8.GetBytes(_geradorDeSenha.Gerar(senhaUsuario));
                hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));

                hashLeft = Convert.ToBase64String(hmac.Hash);
                hashRight = string.Join(":", siteId, nomeUsuario, ticks.ToString());
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashLeft, hashRight)));
        }
    }
}