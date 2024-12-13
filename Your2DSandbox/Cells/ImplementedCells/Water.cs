using Your2DSandbox.Sim;

namespace Your2DSandbox.Cells.ImplementedCells;

public class Water : MovableCell, IBurnable
{
    public Water()
    {
        CellType = CellType.Water;
        Color = ConsoleColor.DarkBlue;
        Representation = 'W';
        GoesUp = false;
    }
    
    public override void Move(Board b, int h, int w)
    {
        if (MoveVertically(b,h,w)) return;
        MoveHorizontallyErratically(b, h, w);
    }
    
    public bool Burn(Board b, int h, int w)
    {
        b.Cells[h, w] = new Steam();
        return true;
    }
}