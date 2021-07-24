using System.Collections.Generic;
using System.Linq;



public class FilesFromConfigSelector : IFilesSelector
{
    public FilesFromConfigSelector(Config config) =>
        this.Config = config;
    public FilesToCompare SelectFilesForFindingSimilarProblems()
    {
        List<string> filesList = new();
        if (Config.SelectedDirectories is not null)
        {
            IDirectoriesSelector dirSelector = new ConstantDirectoriesSelector(
                Config.SelectedDirectories);
            var files = new FilesByDirectoriesSelector(dirSelector)
                .SelectFilesForFindingSimilarProblems();
            filesList.AddRange(files.AllRelevantFiles);
        }
        if (Config.SelectedFiles is not null)
        {
            filesList.AddRange(Config.SelectedFiles.Where(
                System.IO.File.Exists
                ));
        }

        return new FilesToCompare(filesList);
    }
    public Config Config { get; init; }
}