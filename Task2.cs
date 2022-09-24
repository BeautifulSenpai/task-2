using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public static class Task2
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return null;

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (var c in raw)
            {
                if(" -0123456789".Contains(c))
                newNumber.Append(c);
                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);
                    else
                        return null;
                }

            }
            return newNumber.ToString(); 
        }
        static bool Contrains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }
        static readonly string[] digits =
        {
            "ABC","DEF","HGI","JKL","MNO","PQRS","TUV","WXYZ"
        };
        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}
