using System;
using System.Collections.Generic;

namespace GiosAirPollutionClient
{
    internal static class StringExtensions
    {
        public static string Cut(this string input, string from, string to)
        {
            return CutTo(CutFrom(input, from), to);
        }

        public static string CutFrom(this string input, string from)
        {
            var index = input.IndexOf(from, StringComparison.Ordinal);

            return index > 0 ? input.Substring(index + @from.Length) : input;
        }

        public static string CutTo(this string input, string to)
        {
            var index = input.IndexOf(to, StringComparison.Ordinal);

            return index > 0 ? input.Substring(0, index) : input;
        }

        public static string Remove(this string input, IEnumerable<string> items)
        {
            var text = input;

            foreach (var item in items)
                if (!string.IsNullOrEmpty(item))
                    text = text.Replace(item, "");

            return text;
        }
    }
}