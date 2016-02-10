 // ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public interface ILeitorConfiguracoesBancoDeDados
    {
        string BancoDeDados { get; }
        string StringConexao { get; }
    }
}