
namespace Palla.Labs.Vdt.App.Compartilhado
{
    public static class ExtensoesDeBoolean
    {
        public static string ParaTexto(this bool value)
        {
            return value ? "Sim" : "Não";
        }
    }
}