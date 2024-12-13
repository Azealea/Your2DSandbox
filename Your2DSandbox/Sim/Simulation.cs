using Your2DSandbox.Cells;

namespace Your2DSandbox.Sim;

public class Simulation
{
    public Board Board { get;}

    public int CursorH { get; private set;}
    public int CursorW { get; private set;}
    
    public bool Pause { get; private set; }
    public bool Step { get; private set; }
    
    public CellType SelectedCellType { get; private set; }
    
    public Simulation(int h, int w, int seed=0)
    {
        Board = new Board(h, w, seed);
        CursorH = h / 2;
        CursorW = w / 2;
        SelectedCellType = CellType.Rock;
        Pause = true;
    }
    
    // Run the simulation at the given 'speed', with the correct graphics, while handling input
    public void RunSimulation(int delayPerFrame, bool blockRepresentation = false)
    {
        while (true)
        {
            DisplayBoard(blockRepresentation);
            if (!Pause || Step)
            {
                Board.NextBoard();
                Step = false;
            }
            if(HandleInput()) return;
            System.Threading.Thread.Sleep(delayPerFrame);
        }
    }

    // Displays the board and the cursor around it, it can draw the board with full square instead of letters 
    public void DisplayBoard(bool blockRepresentation = false)
    {
        Console.SetCursorPosition(0, 0);
        
        Console.WriteLine(new String('─',CursorW+1) +"v" + new String('─',Board.Width-CursorW) + 
                          (Pause ? "  Paused ":  "  Running") + $" | Cell selected {SelectedCellType}  "  );
        for (int i = 0; i < Board.Height; i++)
        {
            Console.Write(i == CursorH ? ">" : "|");
            for (int j = 0; j < Board.Width; j++)
            {
                if (Board.Cells[i, j] is { } cell)
                {
                    Console.ForegroundColor = cell.Color;
                    Console.Write(blockRepresentation ? "\u2588" :cell.Representation);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine(i == CursorH ? "<" : "|");
        }
        Console.WriteLine(new String('─',CursorW+1) +"^" + new String('─',Board.Width-CursorW));
    }

    
    // Handle input given by the user and returns true when stopping the simulation.
    // Also update Pause and Step, both of them used when running the simulation 
    private bool HandleInput()
    {
        if (!Console.KeyAvailable) return false;
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        
        switch (keyInfo.Key)
        {
            case ConsoleKey.Escape:
                return true;
            case ConsoleKey.LeftArrow:
                if (CursorW > 0) CursorW--;
                break;
            case ConsoleKey.RightArrow:
                if (CursorW < Board.Width - 1) CursorW++;
                break;
            case ConsoleKey.UpArrow:
                if (CursorH > 0) CursorH--;
                break;
            case ConsoleKey.DownArrow:
                if (CursorH < Board.Height - 1) CursorH++;
                break;
            case ConsoleKey.Spacebar:
                Board.SetCell(SelectedCellType,CursorH,CursorW);
                break;
            case ConsoleKey.Backspace:
                Board.SetCell(null, CursorH, CursorW);
                break;
            case ConsoleKey.P:
                Pause = !Pause;
                break;
            case ConsoleKey.Enter:
                Pause = true;
                Step = true;
                break;
            case ConsoleKey.B:
                Board.FillRandom();
                break;
            case ConsoleKey.N:
                Board.FillBoard();
                break;
            case ConsoleKey.E:
                SelectedCellType = CellType.Rock;
                break;
            case ConsoleKey.R:
                SelectedCellType = CellType.Wood;
                break;
            case ConsoleKey.T:
                SelectedCellType = CellType.Sand;
                break;
            case ConsoleKey.Y:
                SelectedCellType = CellType.Water;
                break;
            case ConsoleKey.U:
                SelectedCellType = CellType.Fire;
                break;
            case ConsoleKey.I:
                SelectedCellType = CellType.Steam;
                break;
            case ConsoleKey.O:
                SelectedCellType = CellType.Glass;
                break;
        }
        return false;
    }
}
