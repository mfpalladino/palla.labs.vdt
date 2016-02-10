using System.Configuration;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class LeitorConfiguracoesBancoDeDadosArquivo : ILeitorConfiguracoesBancoDeDados
    {
        public string BancoDeDados
        {
            get { return ConfigurationManager.AppSettings["banco-de-dados"]; }
        }

        public string StringConexao
        {
            get { return ConfigurationManager.AppSettings["string-conexao"]; }
        }
    }
}