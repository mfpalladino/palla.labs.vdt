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

        public static DateTime APartirDeUnixTime(this long unixTime)
        {
            var result = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return result.AddSeconds(unixTime);
        }

        public static long ParaUnixTime(this DateTime dateTime)
        {
            return (Int32)(dateTime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalSeconds;
        }
    }
}