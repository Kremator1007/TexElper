internal static class MainClass
{
    public static void Main()
    {
        var program = new ProgramToFindDuplicates();
        try
        {
            _ = program.RunProgram();
        }
        catch (System.Exception e)
        {
            Serilog.Log.Logger.Error(e, "Exception in the program");
            System.Console.WriteLine("Exception has occured: {0}", e);
        }
    }
}