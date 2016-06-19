using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaUsuario
    {
        public virtual Usuario Criar(Guid siteId, UsuarioDto usuarioDto)
        {
            return Criar(siteId, usuarioDto.Id, usuarioDto);
        }

        public virtual Usuario Criar(Guid siteId, Guid id, UsuarioDto usuarioDto)
        {
            return new Usuario(siteId, id, usuarioDto.Nome, "", (TipoUsuario)usuarioDto.Tipo, usuarioDto.Grupos);
        }
    }
}