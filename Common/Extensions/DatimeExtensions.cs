using System;

namespace Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsNullOrEmpty(DateTime? Fecha)
        {
            if (Fecha == null)
                return true;

            if (Fecha == default(DateTime))
                return true;

            return false;
        }

    }
}


