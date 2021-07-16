using System.Collections.Generic;
using System.Linq;
public partial class Tools
{
    public static int LevenshteinDistance(string a, string b)
    {
        if (a.Length == 0 || b.Length == 0)
        {
            return System.Math.Max(a.Length, b.Length);
        }
        else if (a[0] == b[0])
        {
            return LevenshteinDistance(a[1..], b[1..]);
        }
        else
        {
            return 1 + (new int[]
            {
                LevenshteinDistance(a, b[1..]),
                LevenshteinDistance(a[1..], b),
                LevenshteinDistance(a[1..], b[1..])
            }).Min();
        }
    }
}