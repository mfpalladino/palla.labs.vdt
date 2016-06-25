using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaPermissoesDto
    {
        public virtual PermissoesDto Criar(Usuario usuario)
        {
            if (usuario.TipoUsuario == TipoUsuario.Dono)
                return new PermissoesDto
                {
                    PodeAcessarClientes = true,
                    PodeAcessarEquipamentos = true,
                    PodeAcessarGruposClientes = true,
                    PodeAcessarManutencoes = true,
                    PodeAcessarUsuarios = true
                };

            if (usuario.TipoUsuario == TipoUsuario.Manutenedor)
                return new PermissoesDto
                {
                    PodeAcessarClientes = false,
                    PodeAcessarEquipamentos = true,
                    PodeAcessarGruposClientes = false,
                    PodeAcessarManutencoes = true,
                    PodeAcessarUsuarios = false
                };

            return new PermissoesDto
            {
                PodeAcessarClientes = false,
                PodeAcessarEquipamentos = false,
                PodeAcessarGruposClientes = false,
                PodeAcessarManutencoes = false,
                PodeAcessarUsuarios = false
            };
        }
    }
}