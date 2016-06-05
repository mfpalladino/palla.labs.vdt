using System;
using System.Security.Cryptography;
using System.Text;

namespace Palla.Labs.Vdt.App.Infraestrutura.Seguranca
{
    public class GeradorDeSenha
    {
        private readonly ConfigSeguranca _configSeguranca;

        public GeradorDeSenha(ConfigSeguranca configSeguranca)
        {
            _configSeguranca = configSeguranca;
        }

        public string Gerar(string senha)
        {
            var key = string.Join(":", senha, _configSeguranca.SaltParaCriptografia);

            using (var hmac = HMAC.Create(_configSeguranca.AlgoritmoParaCriptografia))
            {
                hmac.Key = Encoding.UTF8.GetBytes(_configSeguranca.SaltParaCriptografia);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));

                return Convert.ToBase64String(hmac.Hash);
            }
        }
    }
}