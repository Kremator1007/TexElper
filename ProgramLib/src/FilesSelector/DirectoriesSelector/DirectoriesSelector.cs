using System.Collections.Generic;
using System;
using System.Linq;

public interface IDirectoriesSelector
{
    public IEnumerable<string> SelectDirs();
}

