using System.Collections.Generic;

public interface IBackendFileComparer
{
    public abstract ResultData ProcessInput(FilesToCompare inputData);
}