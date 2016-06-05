using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Infraestrutura.Seguranca;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class Login
    {
        private readonly GeradorDeToken _geradorDeToken;

        public Login(GeradorDeToken geradorDeToken)
        {
            _geradorDeToken = geradorDeToken;
        }

        public string Logar(LoginDto login, string ip, string userAgent)
        {
            Validar(login);

            return _geradorDeToken.Gerar(Guid.NewGuid(), login.Usuario, login.Senha,  ip, userAgent, DateTime.UtcNow.Ticks);
        }

        private static void Validar(LoginDto login)
        {
            if (string.IsNullOrWhiteSpace(login.Dominio))
                throw new FormatoInvalido("O domínio deve ser informado.");

            if (string.IsNullOrWhiteSpace(login.Usuario))
                throw new FormatoInvalido("O nome do usuário deve ser informado.");

            if (string.IsNullOrWhiteSpace(login.Senha))
                throw new FormatoInvalido("A senha deve ser informada.");

            if (login.Dominio != "teste" || login.Usuario != "teste" || login.Senha != "teste") //todo REMOVER
                throw new FormatoInvalido("As credenciais informadas não são válidas.");
        }
    }
}