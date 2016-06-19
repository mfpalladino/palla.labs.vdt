using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaUsuarioDto
    {
        public virtual IEnumerable<UsuarioDto> Criar(IEnumerable<Usuario> usuarios)
        {
            return usuarios.Select(Criar).OrderBy(x => x.Nome);
        }

        public virtual UsuarioDto Criar(Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Tipo = (int) usuario.TipoUsuario,
                Grupos = usuario.Grupos
            };
        }
    }
}