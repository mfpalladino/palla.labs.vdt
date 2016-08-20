using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.Infraestrutura.Seguranca;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaUsuario
    {
        private readonly GeradorDeSenha _geradorDeSenha;
        private readonly RepositorioUsuarios _repositorioUsuarios;

        public FabricaUsuario(GeradorDeSenha geradorDeSenha, RepositorioUsuarios repositorioUsuarios)
        {
            _geradorDeSenha = geradorDeSenha;
            _repositorioUsuarios = repositorioUsuarios;
        }

        public virtual Usuario Criar(Guid siteId, UsuarioDto usuarioDto, bool gerarSenha)
        {
            return Criar(siteId, usuarioDto.Id, usuarioDto, gerarSenha);
        }

        public virtual Usuario Criar(Guid siteId, Guid id, UsuarioDto usuarioDto, bool gerarSenha)
        {
            string senha;
            if (!string.IsNullOrWhiteSpace(usuarioDto.Senha) && gerarSenha)
                senha = _geradorDeSenha.Gerar(usuarioDto.Senha);
            else
                senha = _repositorioUsuarios.BuscarPorId(siteId, id).Senha;

            return new Usuario(siteId, id, usuarioDto.Nome, senha, (TipoUsuario)usuarioDto.Tipo, usuarioDto.Grupos, usuarioDto.EstaAtivo);
        }
    }
}