namespace Your2DSandbox.Cells.ImplementedCells;

public class Glass : Cell
{
    public Glass()
    {
        Color = ConsoleColor.Blue;
        CellType = CellType.Glass;
        Representation = 'G';
    }
}