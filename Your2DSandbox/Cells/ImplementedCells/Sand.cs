using Your2DSandbox.Sim;

namespace Your2DSandbox.Cells.ImplementedCells;

public class Sand : MovableCell, IBurnable 
{
    public Sand()
    {
        Color = ConsoleColor.Yellow;
        CellType = CellType.Sand;
        Representation = 'S';
        GoesUp = false;
    }

    public override void Move(Board b, int h, int w)
    {
        MoveVertically(b,h,w);
    }
    
    public bool Burn(Board b, int h, int w)
    {
        b.SetCell(CellType.Glass, h, w);
        b.Cells[h, w] = new Glass();
        return true;
    }
}