using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaPermissoes
    {
        public virtual Permissoes Criar(Usuario usuario)
        {
            if (usuario.TipoUsuario == TipoUsuario.Dono)
                return new Permissoes(true, true, true, true, true);

            if (usuario.TipoUsuario == TipoUsuario.Manutenedor)
                return new Permissoes(false, false, false, true, true);

            return new Permissoes(false, false, false, false, false);
        }
    }
}