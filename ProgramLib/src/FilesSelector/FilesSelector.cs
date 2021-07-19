using System.Collections.Generic;

public interface IFilesSelector
{
    public FilesToCompare SelectFilesForFindingSimilarProblems();
}