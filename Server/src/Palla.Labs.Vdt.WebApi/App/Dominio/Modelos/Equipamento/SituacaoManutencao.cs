 // ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public enum SituacaoManutencao
    {
        Todos = -1,
        Ok = 1,
        EstadoDeAtencao = 2,
        EstadoCritico = 3,
        Inconclusivo = 4 //equipamento não possui manutenções
    }
}