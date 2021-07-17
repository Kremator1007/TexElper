public class DummyProblemComparer : IProblemComparer
{
    public bool AreTwoProblemsSimilar(Problem fst, Problem snd)
    {
        return System.Math.Abs(fst.Text.Length - snd.Text.Length) <= 5;
    }
}