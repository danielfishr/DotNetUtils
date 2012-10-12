using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetUtils
{
    public static class EnumUtil
    {
        public static T Parse<T>(string val)
        {
            return (T) Enum.Parse(typeof (T), val);
        }

        public static T Parse<T>(string val, bool ignoreCase)
        {
            return (T)Enum.Parse(typeof(T), val,ignoreCase);
        }

        public static IList<T> List<T>()
        {
            T[] values = (T[])Enum.GetValues(typeof(T));
            return values.ToList();
        }

        public static T Random<T>()
        {
            var values = List<T>();
            return values[RandomUtil.Next(0, values.Count())];
        }

        public static T Parse<T>(string val, bool ignoreCase, T @default) where T : struct
        {
            T result;
            if (Enum.TryParse(val, ignoreCase, out result))
            {
                return result;
            }
            return @default;
        }

        public static T Parse<T>(string val, T @default) where T : struct
        {
            T result;
            if (Enum.TryParse(val, out result))
            {
                return result;
            }
            return @default;
        }

        public static bool CanParse<T>(string text,bool ignoreCase = false) where T : struct
        {
            T t;
            return Enum.TryParse(text, ignoreCase, out t);
        }
    }
}