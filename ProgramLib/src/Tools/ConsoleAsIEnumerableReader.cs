using System.Collections.Generic;
using System.Linq;


public partial class Tools
{
    public static IEnumerable<string> ReadConsoleLines()
    {
        while (true)
        {
            string? input = System.Console.ReadLine();
            if (input is null)
                break;
            else if (input == "")
                break;
            else
                yield return input;
        }
    }
}
