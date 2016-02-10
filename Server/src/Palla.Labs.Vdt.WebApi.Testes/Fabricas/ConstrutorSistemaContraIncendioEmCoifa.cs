using Palla.Labs.Vdt.App.Dominio.Modelos.Equipamento;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorSistemaContraIncendioEmCoifa
    {
        public SistemaContraIncendioEmCoifa Construir()
        {
            return new SistemaContraIncendioEmCoifa("central", 2, 2, 2);
        }
    }
}