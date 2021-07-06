using System.Collections.Generic;
using System.Linq;

namespace UsefulExtensions
{
    public static class PairwiseClass
    {
        public static IEnumerable<(T, T)> Pairwise<T>(this IEnumerable<T> enumerable)
        {
            var asArray = enumerable.ToArray();
            var length = asArray.Length;
            for (int fst = 0; fst < length; ++fst)
            {
                for (int snd = fst + 1; snd < length; ++snd)
                {
                    yield return (asArray[fst], asArray[snd]);
                }
            }
        }
    }
}