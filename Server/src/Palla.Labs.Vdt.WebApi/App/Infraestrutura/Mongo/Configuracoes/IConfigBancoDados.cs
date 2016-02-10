 // ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public interface IConfigBancoDados
    {
        string NomeBancoDados { get; }
        string StringConexao { get; }
    }
}