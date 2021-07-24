using System.Collections.Generic;

namespace UsefulExtensions
{
    public static class ForEachClass
    {
        public static IEnumerable<T> ForEach<T>(
            this IEnumerable<T> enumerable,
            System.Action<T> action)
        {
            foreach (T item in enumerable)
            {
                action(item);
                yield return item;
            }
        }
    }
}