
// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class PermissoesDto
    {
        public bool PodeAcessarUsuarios { get; set; }
        public bool PodeAcessarClientes { get; set; }
        public bool PodeAcessarGruposClientes { get; set; }
        public bool PodeAcessarEquipamentos { get; set; }
        public bool PodeAcessarManutencoes { get; set; }
    }
}