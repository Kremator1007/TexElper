using System.Linq;
using System.IO;

public class FilesByDirectoriesSelector : IFilesSelector
{
    public FilesByDirectoriesSelector(IDirectoriesSelector dirSelector)
        => this.dirSelector = dirSelector;

    public FilesToCompare SelectFilesForFindingSimilarProblems() =>
        new(dirSelector.SelectDirs().SelectMany(
            (string pathToDir) => Directory.EnumerateFiles(pathToDir, "*.tex"))
                .ToList());

    private readonly IDirectoriesSelector dirSelector;
}