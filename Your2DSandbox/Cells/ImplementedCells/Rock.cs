namespace Your2DSandbox.Cells.ImplementedCells;

public class Rock : Cell
{
    public Rock()
    {
        CellType = CellType.Rock;
        Color = ConsoleColor.DarkGray;
        Representation = 'R';
    }
}