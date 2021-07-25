using System.IO;
using System.Linq;
using UsefulExtensions;

public class FilesByDirectoriesSelector : IFilesSelector
{
    public FilesByDirectoriesSelector(IDirectoriesSelector dirSelector)
        => this.dirSelector = dirSelector;

    public Expected<FilesToCompare, string> SelectFilesForFindingSimilarProblems()
    {
        return new ValueWrapper<FilesToCompare, string>(
            new FilesToCompare(
                dirSelector
                    .SelectDirs()
                    .ForEach(dirPath =>
                        Serilog.Log.Information($"Directory {dirPath} selected successfully"))
                    .SelectMany((string pathToDir) => Directory.EnumerateFiles(pathToDir, "*.tex"))
                    .ToList()));
    }

    private readonly IDirectoriesSelector dirSelector;
}