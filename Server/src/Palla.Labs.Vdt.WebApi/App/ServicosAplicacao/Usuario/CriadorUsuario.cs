using System;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class CriadorUsuario
    {
        private readonly RepositorioUsuarios _repositorioUsuarios;
        private readonly FabricaUsuario _fabricaUsuario;
        private readonly FabricaUsuarioDto _fabricaUsuarioDto;

        public CriadorUsuario(RepositorioUsuarios repositorioUsuarios, 
            FabricaUsuario fabricaUsuario,
            FabricaUsuarioDto fabricaUsuarioDto)
        {
            _repositorioUsuarios = repositorioUsuarios;
            _fabricaUsuario = fabricaUsuario;
            _fabricaUsuarioDto = fabricaUsuarioDto;
        }

        public UsuarioDto Criar(Guid siteId, UsuarioDto usuarioDto)
        {
            Validar(siteId, usuarioDto);

            var usuario = _fabricaUsuario.Criar(siteId, Guid.NewGuid(), usuarioDto, gerarSenha:true);
            _repositorioUsuarios.Inserir(usuario);
            return _fabricaUsuarioDto.Criar(usuario);
        }

        private void Validar(Guid siteId, UsuarioDto usuarioDto)
        {
            if (usuarioDto.Id != Guid.Empty)
                throw new FormatoInvalido("O identificador de usuário não deve ser informado neste contexto.");

            if (string.IsNullOrEmpty(usuarioDto.Nome))
                throw new FormatoInvalido("O nome do usuário deve ser informado.");

            if (string.IsNullOrEmpty(usuarioDto.Nome))
                throw new FormatoInvalido("O nome do usuário deve ter no máximo 20 caracteres.");

            if (_repositorioUsuarios.BuscarPorNome(siteId, usuarioDto.Nome) != null)
                throw new FormatoInvalido("Já existe um usuário com o nome informado. ");

            if (string.IsNullOrEmpty(usuarioDto.Senha))
                throw new FormatoInvalido("A senha inicial do usuário deve ser informada.");

            if (!usuarioDto.Tipo.TipoUsuarioValido())
                throw new FormatoInvalido("O tipo do usuário não é válido ou não foi informado.");

            if (usuarioDto.Tipo.TipoUsuarioObrigaGrupos() && (usuarioDto.Grupos == null || usuarioDto.Grupos.Length == 0))
                throw new FormatoInvalido("Um consumidor deve ser associado a pelo menos um grupo.");

            if (!usuarioDto.Tipo.TipoUsuarioObrigaGrupos() && usuarioDto.Grupos != null && usuarioDto.Grupos.Length > 0)
                throw new FormatoInvalido("Este usuário não pode possuir grupos associados.");
        }
    }
}