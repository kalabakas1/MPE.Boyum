using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPE.Boyum.Extensions
{
    public static class DecimalExtensions
    {
        public static string Formatted(this decimal input)
        {
            return input.ToString("N3", CultureInfo.GetCultureInfo("da-DK"));
        }
    }
}
