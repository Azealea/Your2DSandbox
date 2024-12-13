using Your2DSandbox.Cells;
using Your2DSandbox.Sim;

namespace Your2DSandbox.TestSuite;

public static class Test
{
    public static string BoardToString(Board b)
    {
        return "|" +b.Cells.Cast<Cell?>().Aggregate("", (current, c) => current + (c is null ? " " : c.Representation)) + "|";
    }
    
    public static void RunAll()
    {
        Easy.TestSuite();
        Intermediate.TestSuite();
        Hard.TestSuite();
    }
}