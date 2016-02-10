using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class LeitorConfiguracoesBancoDeDadosVariavelAmbiente : ILeitorConfiguracoesBancoDeDados
    {
        public string BancoDeDados
        {
            get { return Environment.GetEnvironmentVariable("vdt-banco-de-dados"); }
        }

        public string StringConexao
        {
            get { return Environment.GetEnvironmentVariable("vdt-string-conexao"); }
        }
    }
}