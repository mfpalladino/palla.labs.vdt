
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Permissoes
    {
        public Permissoes(bool podeAcessarUsuarios,
            bool podeAcessarClientes,
            bool podeAcessarGruposClientes,
            bool podeAcessarEquipamentos,
            bool podeAcessarManutencoes
            )
        {
            PodeAcessarUsuarios = podeAcessarUsuarios;
            PodeAcessarClientes = podeAcessarClientes;
            PodeAcessarGruposClientes = podeAcessarGruposClientes;
            PodeAcessarEquipamentos = podeAcessarEquipamentos;
            PodeAcessarManutencoes = podeAcessarManutencoes;
        }

        public bool PodeAcessarUsuarios { get; private set; }
        public bool PodeAcessarClientes { get; private set; }
        public bool PodeAcessarGruposClientes { get; private set; }
        public bool PodeAcessarEquipamentos { get; private set; }
        public bool PodeAcessarManutencoes { get; private set; }
    }
}