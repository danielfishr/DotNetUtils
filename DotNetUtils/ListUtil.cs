using System.Collections.Generic;

namespace DotNetUtils
{
    public static class ListUtil
    {
        public static IList<T> Create<T>(params T[] ts)
        {
            return new List<T>(ts);
        }

        public static List<T> Join<T>(List<T> list, T item)
        {
            return new List<T>(list)
                       {
                           item
                       };
        }

        public static List<T> Join<T>(T item, IEnumerable<T> list)
        {
            var joined = new List<T>
                             {
                                 item
                             };
            joined.AddRange(list);
            return joined;
        }
    }
}