using Your2DSandbox.Cells.ImplementedCells;

namespace Your2DSandbox.Cells;

public abstract class Cell
{
    public CellType CellType { get; protected set; }
    public ConsoleColor Color  { get; protected set; }
    public char Representation  { get; protected set; }
    
    // Create a new Cell from the CellType
    public static Cell? CellFromCellType(CellType? cellType)
    {
        return cellType switch
        {
            CellType.Water => new Water(),
            CellType.Fire => new Fire(),
            CellType.Wood => new Wood(),
            CellType.Rock => new Rock(),
            CellType.Sand => new Sand(),
            CellType.Steam => new Steam(),
            CellType.Glass => new Glass(),
            _ => null
        };
    }
}