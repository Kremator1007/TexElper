public class ByLevenshteinProblemComparer : IProblemComparer
{
    public bool AreTwoProblemsSimilar(Problem fst, Problem snd)
    {
        if (System.Math.Abs(fst.Text.Length - snd.Text.Length) >= comparingSensitivity)
            return false;
        else
            return Tools.LevenshteinDistance(fst.Text, snd.Text) < comparingSensitivity;
    }
    private readonly int comparingSensitivity = 42;
}