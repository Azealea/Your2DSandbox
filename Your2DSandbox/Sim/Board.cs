using Your2DSandbox.Cells;

namespace Your2DSandbox.Sim;

public class Board
{
    public int Height { get; }
    public int Width { get; }
    public Cell?[,] Cells { get; }
    public Random Random { get; }
    
    public Board(int height,int width, int seed = 0)
    {
        if (height < 1 || width < 1 )
            throw new ArgumentException("Height and width must be greater than 0");

        Height = height;
        Width = width;
        Random = new Random(seed);
        Cells = new Cell[height, width];
        
        for (int h = 0; h < Height; h++)
        for (int w = 0; w < Width; w++)
        {
            Cells[h, w] = null;
        }
    }

    // Set a new cell at the specified coordinates
    // The given Coordinates are in bound
    public void SetCell(CellType? cellType,int h, int w)
    {
        Cells[h, w] = Cell.CellFromCellType(cellType);
    }
    
    // Swap the two object around the 2 dimensional array
    // The given Coordinates are in bound
    public void SwapCells(int h1, int w1, int h2, int w2)
    {
        (Cells[h1, w1], Cells[h2, w2]) = (Cells[h2, w2], Cells[h1, w1]);
    }

    // Fill the board with the specified type of cell
    public void FillBoard(CellType? cellType = null)
    {
        for (int h = 0; h < Height; h++)
        for (int w = 0; w < Width; w++)
        {
            Cells[h, w] = Cell.CellFromCellType(cellType);
        }
    }

    // Fill the board with random cell
    public void FillRandom()
    {
        for (int h = 0; h < Height; h++)
        for (int w = 0; w < Width; w++)
        {
            Cells[h, w] = Cell.CellFromCellType((CellType)Random.Next(7));
        }
    }

    // Loop through a cloned board to keep the original cell, and call Update then Move on the cell
    public void NextBoard()
    {
        var originalCells = (Cell[,])Cells.Clone();

        for (int h = 0; h < Height; h++)
        for (int w = 0; w < Width; w++)
        {
            if (originalCells[h, w] is IUpdatable updatable)
            {
                updatable.Update(this, h, w);
            }
            if (originalCells[h,w] is MovableCell cell)
            {
                cell.Move(this, h, w);
            }
        }
    }
}