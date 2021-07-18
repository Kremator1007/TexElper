using System.Collections.Generic;

public interface IBackendFileComparer
{
    public abstract ResultData CompareFiles(FilesToCompare inputData);
}