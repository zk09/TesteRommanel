using System.Text.RegularExpressions;

namespace System
{
    public static class ExtensionString
    {
        public static string OnlyNumbers(this string str)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            var number = apenasDigitos.Replace(str, "");
            return number;
        }
    }
}
