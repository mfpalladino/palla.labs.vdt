using System;
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
            Validar(usuarioDto);

            var usuario = _fabricaUsuario.Criar(siteId, Guid.NewGuid(), usuarioDto);
            _repositorioUsuarios.Inserir(usuario);
            return _fabricaUsuarioDto.Criar(usuario);
        }

        private static void Validar(UsuarioDto usuarioDto)
        {
            if (usuarioDto.Id != Guid.Empty)
                throw new FormatoInvalido("O identificador de usuário não deve ser informado neste contexto.");
        }
    }
}