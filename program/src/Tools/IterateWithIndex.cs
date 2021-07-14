using System.Collections.Generic;
using System.Linq;

namespace UsefulExtensions
{
    public static class IterationWithIndex
    {
        public static IEnumerable<(T item, int index)> IterateWithIndex<T>(
            this IEnumerable<T> enumerable)
        {
            int cnt = 0;
            foreach (T item in enumerable)
            {
                yield return (item, cnt);
                ++cnt;
            }
        }
    }
}