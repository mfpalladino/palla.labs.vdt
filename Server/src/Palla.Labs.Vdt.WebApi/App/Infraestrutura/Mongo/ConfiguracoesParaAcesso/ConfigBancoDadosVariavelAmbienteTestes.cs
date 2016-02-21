using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public class ConfigBancoDadosVariavelAmbienteTestes : IConfigBancoDados
    {
        public string NomeBancoDados
        {
            get { return Environment.GetEnvironmentVariable("vdt-banco-de-dados-testes"); }
        }

        public string StringConexao
        {
            get { return Environment.GetEnvironmentVariable("vdt-string-conexao-testes"); }
        }
    }
}