using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlystaTest
{
   public static class StringExtension
    {
        public static string[] Split(this string text, char _split)
        {
            int size = sizeArray(text, _split);
            var result = new string[size];
            int index = 0;
            var startIndex = 0;
            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == _split)
                {
                    result[index++] = text.SubstringExt(startIndex, i - startIndex);
                    startIndex = ++i;
                }
                else if (i == text.Length - 1)
                {
                    result[index++] = text.SubstringExt(startIndex, i - startIndex);
                }
            }
            return result;
        }

        public static int sizeArray(this string text, char _split)
        {
            return text.Count(letter => letter.Equals(_split));
        }

        public static string SubstringExt(this string text, int startIndex, int lenght)
        {
            var boof = new char[lenght];
            var index = 0;
            for (var i = startIndex; i < text.Length; i++)
            {
                boof[index++] = text[i];
                if (index >= lenght) break;
            }
            return new string(boof);
        }
    }
}
