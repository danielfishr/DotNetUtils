using System.Collections.Generic;

namespace DotNetUtils
{
    public static class ListUtil
    {
        public static IList<T> From<T>(params T[] ts)
        {
            return new List<T>(ts);
        }
    }
}