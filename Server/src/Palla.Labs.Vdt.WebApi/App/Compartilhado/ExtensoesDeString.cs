using System;

namespace Palla.Labs.Vdt.App.Compartilhado
{
    public static class ExtensoesDeString
    {
        public static bool GuidValido(this string guid)
        {
            Guid guidParseado;
            return !String.IsNullOrWhiteSpace(guid) && Guid.TryParse(guid, out guidParseado);
        }
    }
}