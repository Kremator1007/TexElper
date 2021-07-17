using System.Collections.Generic;

public interface IBackendRunner
{
    public abstract ResultData ProcessInput(InputData inputData);
}