using System;

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
    }
}