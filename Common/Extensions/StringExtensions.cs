namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static string RemoverNumero(this string s)
        {
            char[] Numero = { '0', '1', '2', '3', '4', '5', '7', '8', '9' };
            return s.Trim(Numero);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
    }
}