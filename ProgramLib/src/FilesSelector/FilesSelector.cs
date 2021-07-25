public interface IFilesSelector
{
    public Expected<FilesToCompare, string> SelectFilesForFindingSimilarProblems();
}