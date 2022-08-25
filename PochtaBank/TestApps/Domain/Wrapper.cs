using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Converters;

namespace Domain
{
    public class Wrapper
    {
        private const int numberSize = 11;

        private readonly char[] rubbishSymbols = new char[] { '-', '(', ')' };

        public int GetNumberPosition(string input)
        {
            var items = input.Split("/");

            for (var i = 0; i < items.Length; i++)
            {
                if (items[i].Length < numberSize)
                    continue;

                if (items[i].Length == numberSize
                    || items[i].Any(j => !char.IsDigit(j)))
                    return i;

                var cleanStr = GetCleanString(items[i], rubbishSymbols);
                if (cleanStr?.Length != numberSize
                    || items[i].Any(j => !char.IsDigit(j)))
                    continue;

                return i;
            }

            return 0;
        }

        string? GetCleanString(string source, char[] rubbishSymbols)
        {
            var sourceDictionary = source.ConvToDictionary();

            foreach (var i in rubbishSymbols)
            {
                if (sourceDictionary.ContainsKey((int)i))
                    sourceDictionary.Remove((int)i);
            }

            return sourceDictionary?.Select(i => i.Value)?.ToString();
        }
    }
}
