class ActualProblemComparer : ProblemComparer
{
    public override bool AreTwoProblemsSimilar(Problem fst, Problem snd)
    {
        if (System.Math.Abs(fst.Text.Length - snd.Text.Length) >= 42)
            return false;
        else
            return Tools.LevenshteinDistance(fst.Text, snd.Text) < 42;
    }
}