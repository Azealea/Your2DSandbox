using Your2DSandbox.Sim;

namespace Your2DSandbox.Cells.ImplementedCells;

public class Steam : MovableCell,IUpdatable,IBurnable
{
    public int CondensationTimer { get; private set; }
    
    public Steam()
    {
        Color = ConsoleColor.Gray;
        CellType = CellType.Steam;
        Representation = 'V';
        CondensationTimer = 50;
        GoesUp = true;
    }
    
    public override void Move(Board b, int h, int w)
    {
        if (MoveVertically(b,h,w)) return;
        MoveHorizontallyErratically(b, h, w);
    }
    
    public  void Update(Board b, int h, int w)
    {
        CondensationTimer -= 1;
        if (CondensationTimer < 1)
        {
            b.SetCell(CellType.Water, h, w);
        }
    }
    
    public bool Burn(Board b, int h, int w)
    {
        CondensationTimer = 50;
        return false;
    }

}
