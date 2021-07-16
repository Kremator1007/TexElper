public class DummyProblemComparer : ProblemComparer
{
    public override bool AreTwoProblemsSimilar(Problem fst, Problem snd)
    {
        return System.Math.Abs(fst.Text.Length - snd.Text.Length) <= 5;
    }
}