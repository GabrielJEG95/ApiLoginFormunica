using System;

namespace Common.Extensions
{
    public static class GenericsExtensions
    {
        public static bool IsNullOrDefault<T>(this Nullable<T> value) where T : struct
        {
            return default(T).Equals(value.GetValueOrDefault());
        }

        public static bool IsValue<T>(this Nullable<T> value, T valueToCheck) where T : struct
        {
            return valueToCheck.Equals((value ?? valueToCheck));
        }

        public static bool IsNullOrEmptyArray<T>(this Nullable<T>[] s) where T : struct
        {
            return s == null ? true : s.Length == 0;
        }

        public static bool IsNullOrEmptyArray(this string[] s)
        {
            return s == null ? true : s.Length == 0;
        }


    }
}