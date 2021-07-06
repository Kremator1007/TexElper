using System.Collections.Generic;
using System.Linq;
public partial class Tools
{
    public static int LevenshteinDistance(string a, string b)
    {
        string tailA = a.Substring(1), tailB = b.Substring(1);
        if (a.Length == 0 || b.Length == 0)
        {
            return System.Math.Max(a.Length, b.Length);
        }
        else if (a[0] == b[0])
        {
            return LevenshteinDistance(tailA, tailB);
        }
        else
        {
            return 1 + (new List<int>()
            {
                LevenshteinDistance(a, tailB),
                LevenshteinDistance(tailA, b),
                LevenshteinDistance(tailA, tailB)
            }).Min();
        }
    }
}