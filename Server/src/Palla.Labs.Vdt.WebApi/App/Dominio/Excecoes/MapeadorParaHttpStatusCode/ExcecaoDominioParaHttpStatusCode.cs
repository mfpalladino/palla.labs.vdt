using System;
using System.Collections.Generic;
using System.Net;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Excecoes
{
    public static class ExcecaoParaHttpStatusCode
    {
        public static Dictionary<Type, HttpStatusCode> Dicionario()
        {
            return new Dictionary<Type, HttpStatusCode>
            {
                {typeof(FormatoInvalido), HttpStatusCode.BadRequest},
                {typeof(RecursoNaoEncontrado), HttpStatusCode.NotFound}
            };
        }
    }
}