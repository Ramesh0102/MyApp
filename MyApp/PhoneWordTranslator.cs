using System;
using System.Text;

namespace Core
{
    public static class PhoneWordTranslator
    {
        public static string ToNumber(string wordPhoneNumber)
        {
            if (string.IsNullOrWhiteSpace(wordPhoneNumber))
                return null;

            wordPhoneNumber = wordPhoneNumber.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (var c in wordPhoneNumber){
                if ("-0123456789".Contains(c))
                    newNumber.Append(c);
                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);
                    // Bad character
                    else
                        return null;
                }
            }
            return newNumber.ToString();
        }

        static bool Contains(this string keyString, char c){
            return keyString.IndexOf(c) >= 0;
        }

        static readonly string[] digits = {
            "ABC", "DEF", "GHI","JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        private static object TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++){
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}