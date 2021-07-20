using System.Linq;
using System.IO;
using UsefulExtensions;

public class FilesByDirectoriesSelector : IFilesSelector
{
    public FilesByDirectoriesSelector(IDirectoriesSelector dirSelector)
        => this.dirSelector = dirSelector;

    public FilesToCompare SelectFilesForFindingSimilarProblems() =>
        new(dirSelector.SelectDirs()
            .ForEach(dirPath => Serilog.Log.Information($"Directory {dirPath} selected successfully"))
            .SelectMany(
                (string pathToDir) => Directory.EnumerateFiles(pathToDir, "*.tex"))
            .ToList());

    private readonly IDirectoriesSelector dirSelector;
}