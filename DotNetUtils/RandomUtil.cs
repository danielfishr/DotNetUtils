using System;

namespace DotNetUtils
{
    public static class RandomUtil
    {
        private static readonly Random _random = new Random();
        /// <summary>
        /// A more sane API prevents common mistake of the same seed causing seemingly none random numbers.
        /// Prevents Random _random = new Random(); being duplicated everywhere
        /// </summary>
        /// <param name="inclusiveMinVal"></param>
        /// <param name="exclusiveMaxVal"></param>
        /// <returns></returns>
        public static int Next(int inclusiveMinVal, int exclusiveMaxVal)
        {
            return _random.Next(inclusiveMinVal, exclusiveMaxVal);
        }
    }
}