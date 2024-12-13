using Your2DSandbox.Sim;

namespace Your2DSandbox.Cells;

public abstract class MovableCell : Cell
{
    // Used to determine if the cell goes up or down in the vertical movement
    public bool GoesUp { get; protected set; }
    
    public abstract void Move(Board b, int h, int w);
    
    // Used to determine the weight of a cell. A cell can only switch cell with another if they are 'heavier'
    public static int GetCellWeight(CellType cellType)
    {
        return cellType switch
        {
            CellType.Steam => 0,
            CellType.Fire => 1,
            CellType.Water => 2,
            CellType.Sand => 3,
            _ => int.MaxValue
        };
    }
    
    // Try to move a cell from a point to another, returns true if the move is successfully achieved
    // The given coordinates of origin are in bound
    public bool TryMove(Board b, int hFrom, int wFrom, int hTo, int wTo)
    {
        if (0 > hTo || hTo >= b.Height || 0 > wTo || wTo >= b.Width ||
            (b.Cells[hTo, wTo] is not null &&
             GetCellWeight(CellType) <= GetCellWeight(b.Cells[hTo, wTo]!.CellType)))
        {
            return false;
        }
        b.SwapCells(hFrom, wFrom, hTo, wTo);
        return true;
    }

    // Try to move a cell vertically upwards or downwards, returns a bool if the move is successfully achieved 
    // The given coordinates are in bound
    public bool MoveVertically(Board b, int h, int w)
    {
        int newHeight = h + (GoesUp ? -1 : 1);
        return  TryMove(b,h,w,newHeight ,w) || 
                TryMove(b,h,w,newHeight,w-1) || 
                TryMove(b,h,w,newHeight,w+1);
    }

    // Try to move a cell horizontally a little bit randomly, returns a bool if the move is successfully achieved 
    // The given coordinates are in bound
    public bool MoveHorizontallyErratically(Board b, int h, int w)
    {
        return b.Random.Next(3) switch
        {
            0 => TryMove(b, h, w, h, w - 1),
            1 => TryMove(b, h, w, h, w + 1),
            _ => false
        };
    }
}