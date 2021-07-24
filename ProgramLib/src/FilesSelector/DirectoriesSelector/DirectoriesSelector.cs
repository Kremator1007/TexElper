using System.Collections.Generic;

public interface IDirectoriesSelector
{
    public IEnumerable<string> SelectDirs();
}

