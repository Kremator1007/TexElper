using System.Collections.Generic;
using System.Linq;



public class FilesFromConfigSelector : IFilesSelector
{
    public FilesFromConfigSelector(Config config) =>
        this.Config = config;
    public FilesToCompare SelectFilesForFindingSimilarProblems()
    {
        List<string> filesList = new();
        IDirectoriesSelector dirSelector = new ConstantDirectoriesSelector(
            Config.SelectedDirectories);

        ExtractFilesFromConfigDirectories(filesList, dirSelector);
        ExtractFilesFromConfigFilesList(filesList);

        return new FilesToCompare(filesList);
    }

    private void ExtractFilesFromConfigFilesList(List<string> filesList)
    {
        Serilog.Log.Logger.Verbose("Extracting files from config's files list");
        string[] extractedFiles = Config.SelectedFiles.Where(
                    System.IO.File.Exists
                    ).ToArray();
        string logFileList = string.Join('\n', extractedFiles);
        Serilog.Log.Logger.Verbose("The following files were successfuly extracted:\n" + logFileList);
        filesList.AddRange(extractedFiles);
    }

    private static void ExtractFilesFromConfigDirectories(List<string> filesList, IDirectoriesSelector dirSelector)
    {
        var filesFromDirectories = new FilesByDirectoriesSelector(dirSelector)
            .SelectFilesForFindingSimilarProblems();
        filesList.AddRange(filesFromDirectories.AllRelevantFiles);
    }

    public Config Config { get; init; }
}