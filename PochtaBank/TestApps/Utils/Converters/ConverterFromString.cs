using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Converters
{
    public static class ConverterFromString
    {
        public static Dictionary<int, char> ConvToDictionary(this string source)
        {
            var sourceDictionary = new Dictionary<int, char>(source.Length);

            foreach (char c in source)
            {
                sourceDictionary.Add((int)c, c);
            }

            return sourceDictionary;
        }
    }
}
