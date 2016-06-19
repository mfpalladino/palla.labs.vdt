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
            Validar(siteId, id);
            _repositorioUsuarios.Editar(_fabricaUsuario.Criar(siteId, id.ParaGuid(), usuarioDto));
        }

        private void Validar(Guid siteId, string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de usuario informado não é válido.");

            if (_repositorioUsuarios.BuscarPorId(siteId, new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Usuario não encontrado");
        }
    }
}