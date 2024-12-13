using Your2DSandbox.Sim;

namespace Your2DSandbox.Cells.ImplementedCells;

public class Fire : MovableCell, IUpdatable
{
    public int Lifetime { get; private set; }
    
    public Fire()
    {
        CellType = CellType.Fire;
        Color = ConsoleColor.Red;
        Representation = 'F';
        Lifetime = 7;
        GoesUp = true;
    }

    // Try to trigger the burn method at specified coordinates,
    // return true if it burned the cell at the specified coordinates and the fire needs to be extinguished
    private bool TryBurn(Board b,int hTo, int wTo)
    {
        return hTo >= 0 && hTo < b.Height && wTo >= 0 && wTo < b.Width && 
               b.Cells[hTo, wTo] is IBurnable burnable &&
               burnable.Burn(b, hTo, wTo);
    }
    
    public override void Move(Board b,int h, int w)
    {        
        switch (b.Random.Next(2))
        {
            case 0:
                MoveVertically(b, h, w);
                break;
            case 1:
                MoveHorizontallyErratically(b, h, w);
                break;
        }
    }
    
    public void Update(Board b,int h, int w)
    {
        if (TryBurn(b, h - 1, w) | TryBurn(b, h + 1, w) |
            TryBurn(b, h, w - 1) | TryBurn(b, h, w + 1))
        {
            b.SetCell(null,h,w);
        }
        
        Lifetime -= b.Random.Next(2);
        if (Lifetime <1 )
        {
            b.SetCell(null,h,w);
            return;
        }
    }
}