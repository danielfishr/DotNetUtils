namespace DotNetUtils
{
    using System;

    public static class GuidUtil
    {
        public static Guid Parse(string str)
        {
            Guid result;
            bool @throw = false;
            if (!Guid.TryParse(str, out result))
            {
                if (str.Length == 32)
                {
                    str = str.Substring(0, 8) + "-" + str.Substring(8, 4) + "-" + str.Substring(12, 4) + "-" +
                          str.Substring(16, 4) + "-" +
                          str.Substring(20, 12);

                    if (!Guid.TryParse(str, out result))
                    {
                        @throw = true;
                    }
                }
                else
                {
                    @throw = true;
                }
            }
            if (@throw)
            {
                throw new Exception(string.Format("Could not parse {0} into Guid ", str));
            }
            return result;
        }

        public static bool Parsable(object obj)
        {
            Guid guid = Guid.NewGuid();
            return TryParse(obj, guid) != guid;
        }

        public static Guid? GetNullableGuid(string guidAsString)
        {
            Guid? guid = null;
            if (Parsable(guidAsString))
            {
                guid = GuidUtil.Parse(guidAsString);
            }
            return guid;
        }

        public static Guid? TryParseAsNullable(string s, Guid? @default)
        {
            try
            {
                if (Parsable(s))
                {
                    return Parse(s);
                }
            }
// ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }
            return @default;
        }

        public static Guid TryParse(object authorizationId, Guid defaultTo)
        {
            if (authorizationId == null || string.IsNullOrWhiteSpace(authorizationId.ToString()))
            {
                return defaultTo;
            }
            try
            {
                return Parse(authorizationId.ToString());
            }
            catch
            {
                return defaultTo;
            }
        }
    }
}