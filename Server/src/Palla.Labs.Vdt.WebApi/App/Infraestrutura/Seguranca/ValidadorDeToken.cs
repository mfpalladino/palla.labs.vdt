using System;
using System.Text;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

namespace Palla.Labs.Vdt.App.Infraestrutura.Seguranca
{
    public class ValidadorDeToken
    {
        private readonly GeradorDeToken _geradorDeToken;
        private readonly RepositorioUsuarios _repositorioUsuarios;
        private const int MinutosParaExpirar = 60;

        public ValidadorDeToken(GeradorDeToken geradorDeToken, RepositorioUsuarios repositorioUsuarios)
        {
            _geradorDeToken = geradorDeToken;
            _repositorioUsuarios = repositorioUsuarios;
        }

        public bool Validar(string token, string ip, string userAgent, out Guid siteId)
        {
            var resultado = false;
            const short numeroDePartesDoToken = 4;
            var siteIdToken = Guid.Empty;

            try
            {
                var chave = Encoding.UTF8.GetString(Convert.FromBase64String(token));

                var partesDaChave = chave.Split(':');
                if (partesDaChave.Length == numeroDePartesDoToken)
                {
                    siteIdToken = new Guid(partesDaChave[1]);
                    var nomeUsuarioToken = partesDaChave[2];
                    var ticks = long.Parse(partesDaChave[3]);
                    var timeStamp = new DateTime(ticks);

                    var tokenExpirou = Math.Abs((DateTime.UtcNow - timeStamp).TotalMinutes) > MinutosParaExpirar;
                    if (!tokenExpirou)
                    {
                        var usuario = _repositorioUsuarios.BuscarPorNome(siteIdToken, nomeUsuarioToken);
                        if (usuario != null)
                        {
                            var tokenCalculado = _geradorDeToken.Gerar(siteIdToken, nomeUsuarioToken, usuario.Senha, ip, userAgent, ticks);
                            resultado = token == tokenCalculado;
                        }
                    }
                }
            }
            catch
            {
                resultado = false;
            }

            siteId = siteIdToken;
            return resultado;
        }        
    }
}