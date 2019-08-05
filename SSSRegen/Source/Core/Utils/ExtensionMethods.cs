using System;
using System.Linq;

namespace SSSRegen.Source.Core.Utils
{
    public static class ExtensionMethods
    {
        public static int ToInt(this float fl)
        {
            return (int) fl;
        }

        public static float ToFloat(this double dbl)
        {
            return (float) dbl;
        }

        public static int ToInt(this double dbl)
        {
            return (int) dbl;
        }

        /// <summary>
        /// Returns a random number from one of the given ranges.
        /// Minimum and Maximum values are inclusive.
        /// Range is selected randomly.
        /// </summary>
        /// <param name="random"></param>
        /// <param name="ranges">Ranges of Min/Max values used to generate a random number.</param>
        /// <returns></returns>
        public static int RandomInRanges(this Random random, Tuple<int, int>[] ranges)
        {
            int length = ranges.Length;

            var index = random.Next(0, length);

            return random.Next(ranges[index].Item1, ranges[index].Item2 + 1);
        }
    }
}