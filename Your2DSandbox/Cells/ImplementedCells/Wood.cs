using Your2DSandbox.Sim;

namespace Your2DSandbox.Cells.ImplementedCells;

public class Wood : Cell, IBurnable
{
    public Wood()
    {
        Color = ConsoleColor.DarkYellow;
        CellType = CellType.Wood;
        Representation = 'B';
    }

    public bool Burn(Board b, int h, int w)
    {
        b.SetCell(CellType.Fire, h, w);
        return false;
    }
}