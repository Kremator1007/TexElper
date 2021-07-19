using System;
using System.Linq;
using System.Collections.Generic;

public class ConstantDirectoriesSelector : IDirectoriesSelector
{
    public ConstantDirectoriesSelector(string[] directories) =>
        this.directories = directories
            .Where(System.IO.Directory.Exists)
            .ToArray();

    public IEnumerable<string> SelectDirs()
    {
        return directories;
    }
    private readonly string[] directories;
}