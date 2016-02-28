using System;
using System.Linq;

namespace Palla.Labs.Vdt.App.Compartilhado
{
    public static class ExtensoesDeString
    {
        public static bool GuidValido(this string guid)
        {
            Guid guidParseado;
            return !String.IsNullOrWhiteSpace(guid) && Guid.TryParse(guid, out guidParseado);
        }

        public static Guid ParaGuid(this string guid)
        {
            return new Guid(guid);
        }

        public static bool ContemSomenteDigitos(this string valor)
        {
            return valor.All(c => c >= '0' && c <= '9');
        }
    }
}