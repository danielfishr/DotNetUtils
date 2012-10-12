using System;

namespace DotNetUtils
{
    public static class RandomUtil
    {
        private static Random random = new Random();

        public static int Next(int inclusiveMinValue, int exclusiveMaxValue)
        {
            return random.Next(inclusiveMinValue,exclusiveMaxValue)
        }
    }
}