using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.Infraestrutura.Seguranca;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class Login
    {
        private readonly GeradorDeToken _geradorDeToken;
        private readonly GeradorDeSenha _geradorDeSenha;
        private readonly RepositorioSites _repositorioSites;
        private readonly RepositorioUsuarios _repositorioUsuarios;
        private readonly FabricaPermissoes _fabricaPermissoesDto;

        public Login(GeradorDeToken geradorDeToken,
            GeradorDeSenha geradorDeSenha, 
            RepositorioSites repositorioSites, 
            RepositorioUsuarios repositorioUsuarios,
            FabricaPermissoes fabricaPermissoesDto)
        {
            _geradorDeToken = geradorDeToken;
            _geradorDeSenha = geradorDeSenha;
            _repositorioSites = repositorioSites;
            _repositorioUsuarios = repositorioUsuarios;
            _fabricaPermissoesDto = fabricaPermissoesDto;
        }

        public ResultadoLogin Logar(LoginDto login, string ip, string userAgent)
        {
            Validar(login);

            var site = _repositorioSites.BuscarPorNome(login.Dominio);
            if (site == null)
                throw new FormatoInvalido("As credenciais informadas não são válidas.");

            var usuario = _repositorioUsuarios.BuscarPorNome(site.Id, login.Usuario);
            if (usuario == null)
                throw new FormatoInvalido("As credenciais informadas não são válidas.");

            var senha = _geradorDeSenha.Gerar(login.Senha);
            if (senha != usuario.Senha)
                throw new FormatoInvalido("As credenciais informadas não são válidas.");

            return new ResultadoLogin(
                _geradorDeToken.Gerar(site.Id, login.Usuario, usuario.Senha, ip, userAgent, DateTime.UtcNow.Ticks),
                _fabricaPermissoesDto.Criar(usuario));
        }

        private static void Validar(LoginDto login)
        {
            if (string.IsNullOrWhiteSpace(login.Dominio))
                throw new FormatoInvalido("O domínio deve ser informado.");

            if (string.IsNullOrWhiteSpace(login.Usuario))
                throw new FormatoInvalido("O nome do usuário deve ser informado.");

            if (string.IsNullOrWhiteSpace(login.Senha))
                throw new FormatoInvalido("A senha deve ser informada.");
        }
    }
}