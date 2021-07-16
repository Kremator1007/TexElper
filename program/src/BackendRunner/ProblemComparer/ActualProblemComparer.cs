class ActualProblemComparer : ProblemComparer
{
    public override bool CompareTwoProblems(Problem fst, Problem snd)
    {
        return Tools.LevenshteinDistance(fst.Text, snd.Text) < 42;
    }
}