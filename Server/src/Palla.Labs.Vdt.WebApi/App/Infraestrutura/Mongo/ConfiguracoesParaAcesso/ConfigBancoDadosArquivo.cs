using System.Configuration;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class ConfigBancoDadosArquivo : IConfigBancoDados
    {
        public string NomeBancoDados
        {
            get { return ConfigurationManager.AppSettings["banco-de-dados"]; }
        }

        public string StringConexao
        {
            get { return ConfigurationManager.AppSettings["string-conexao"]; }
        }
    }
}