using System.Collections.Generic;
public partial class Tools
{
    public static IEnumerable<(T1, T2)> CartesianProduct<T1, T2>(IEnumerable<T1> enum1, IEnumerable<T2> enum2)
    {
        foreach (var fst in enum1)
        {
            foreach (var snd in enum2)
            {
                yield return (fst, snd);
            }
        }
    }
}