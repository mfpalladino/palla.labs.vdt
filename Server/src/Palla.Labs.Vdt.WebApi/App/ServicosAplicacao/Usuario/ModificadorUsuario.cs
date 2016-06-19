using System;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ModificadorUsuario
    {
        private readonly RepositorioUsuarios _repositorioUsuarios;
        private readonly FabricaUsuario _fabricaUsuario;

        public ModificadorUsuario(RepositorioUsuarios repositorioUsuarios, FabricaUsuario fabricaUsuario)
        {
            _repositorioUsuarios = repositorioUsuarios;
            _fabricaUsuario = fabricaUsuario;
        }

        public void Modificar(Guid siteId, string id, UsuarioDto usuarioDto)
        {
            Validar(siteId, id, usuarioDto);
            _repositorioUsuarios.Editar(_fabricaUsuario.Criar(siteId, id.ParaGuid(), usuarioDto, gerarSenha:false));
        }

        private void Validar(Guid siteId, string id, UsuarioDto usuarioDto)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de usuario informado não é válido.");

            if (_repositorioUsuarios.BuscarPorId(siteId, new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Usuario não encontrado");

            if (string.IsNullOrEmpty(usuarioDto.Nome))
                throw new FormatoInvalido("O nome do usuário deve ser informado.");

            if (string.IsNullOrEmpty(usuarioDto.Nome))
                throw new FormatoInvalido("O nome do usuário deve ter no máximo 20 caracteres.");

            if (_repositorioUsuarios.BuscarPorNomeExcetoId(siteId, usuarioDto.Nome, new Guid(id)) != null)
                throw new FormatoInvalido("Já existe um usuário com o nome informado. ");

            if (!string.IsNullOrEmpty(usuarioDto.Senha))
                throw new FormatoInvalido("A senha do usuário não deve ser informada neste contexto.");

            if (!usuarioDto.Tipo.TipoUsuarioValido())
                throw new FormatoInvalido("O tipo do usuário não é válido ou não foi informado.");

            if (usuarioDto.Tipo.TipoUsuarioObrigaGrupos() && (usuarioDto.Grupos == null || usuarioDto.Grupos.Length == 0))
                throw new FormatoInvalido("Um consumidor deve ser associado a pelo menos um grupo.");

            if (!usuarioDto.Tipo.TipoUsuarioObrigaGrupos() && usuarioDto.Grupos != null && usuarioDto.Grupos.Length > 0)
                throw new FormatoInvalido("Este usuário não pode possuir grupos associados.");
        }
    }
}