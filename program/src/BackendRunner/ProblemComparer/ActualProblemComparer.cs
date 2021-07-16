class ActualProblemComparer : ProblemComparer
{
    public override bool AreTwoProblemsSimilar(Problem fst, Problem snd)
    {
        return Tools.LevenshteinDistance(fst.Text, snd.Text) < 42;
    }
}