using System;
using System.Text;

namespace DotNetUtils
{
    public static class RandomUtil
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// A more sane API prevents common mistake of the same seed causing seemingly none random numbers.
        /// Prevents Random _random = new Random(); being duplicated everywhere
        /// </summary>
        /// <param name="inclusiveMinVal"></param>
        /// <param name="exclusiveMaxVal"></param>
        /// <returns></returns>
        public static int Next(int inclusiveMinVal, int exclusiveMaxVal)
        {
            return Random.Next(inclusiveMinVal, exclusiveMaxVal);
        }

        public static bool Bool()
        {
            return Random.Next(2) == 1;
        }

        public static double NextDouble()
        {
            return Random.NextDouble();
        }

        
        public static string RandomString(int size)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26*RandomUtil.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public static int RandomInt()
        {
            return Random.Next(0, int.MaxValue);
        }

        public static string Email()
        {
            return string.Format("{0}@{1}.com",RandomString(10), RandomString(10));
        }
    }
}