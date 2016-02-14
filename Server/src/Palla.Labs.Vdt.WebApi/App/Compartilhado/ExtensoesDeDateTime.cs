using System;

namespace Palla.Labs.Vdt.App.Compartilhado
{
    public static class ExtensoesDeDateTime
    {
        public static DateTime PrimeiroDiaDoMes(this DateTime data)
        {
            return new DateTime(data.Year, data.Month, 1);
        }

        public static DateTime UltimoDiaDoMes(this DateTime data)
        {
            return new DateTime(data.Year, data.Month + 1, 1).AddDays(-1);
        }
    }
}