using System.Collections.Generic;
using System.Linq;

namespace DotNetUtils
{
    public static class QueryableUtil
    {
        public static IQueryable<T> Create<T>(params T[] ts)
        {
            return new List<T>(ts).AsQueryable();
        }

        public static IQueryable<T> Join<T>(List<T> list, T item)
        {
            return new List<T>(list)
                       {
                           item
                       }.AsQueryable();
        }

        public static IQueryable<T> Join<T>(T item, IEnumerable<T> list)
        {
            var joined = new List<T>
                             {
                                 item
                             };
            joined.AddRange(list);
            return joined.AsQueryable();
        }
    }
}