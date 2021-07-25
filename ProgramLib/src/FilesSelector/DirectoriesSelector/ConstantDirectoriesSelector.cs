using System.Linq;

public class ConstantDirectoriesSelector : IDirectoriesSelector
{
    public ConstantDirectoriesSelector(string[] directories) =>
        this.directories = directories
            .Where(System.IO.Directory.Exists)
            .ToArray();

    public string[] SelectDirs()
    {
        return directories;
    }
    private readonly string[] directories;
}