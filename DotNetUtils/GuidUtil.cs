using System;

namespace DotNetUtils
{
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
    }
}