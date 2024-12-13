using Your2DSandbox.Cells;
using Your2DSandbox.Cells.ImplementedCells;
using Your2DSandbox.Sim;

namespace Your2DSandbox.TestSuite;

public static class Intermediate
{
    public static void TestSuite()
    {
        int testPassed = 0;
        int testNb = 0;
        
        try
        {
            testNb++;
            var s = new Simulation(10,21,-1);
            if (s.Board.Height != 10) throw new Exception("Simulation: Board is incorrect");
            if (s.Board.Width != 21) throw new Exception("Simulation: Board is incorrect");
            if (s.Board.Random.Next(800) != new Random(-1).Next(800)) 
                throw new Exception("Simulation: Board is incorrect");
            if (s.CursorH != 5) throw new Exception("Simulation: CursorH is incorrect");
            if (s.CursorW != 10) throw new Exception("Simulation: CursorW is incorrect");
            if (!s.Pause) throw new Exception("Simulation: Pause is incorrect");
            if (s.Step) throw new Exception("Simulation: Step is incorrect");
            if (s.SelectedCellType != CellType.Rock) 
                throw new Exception("Simulation: SelectedCellType is incorrect");
            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        #region MovableCellConstructor
        
        try
        {
            testNb++;
            var fire = new Fire();
            if (fire.CellType != CellType.Fire) throw new Exception("Fire: CellType is incorrect");
            if (fire.Color != ConsoleColor.Red) throw new Exception("Fire: Color is incorrect");
            if (fire.Representation != 'F') throw new Exception("Fire: Representation is incorrect");
            if (!fire.GoesUp) throw new Exception("Fire: GoesUp is incorrect");
            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        try
        {
            testNb++;
            var steam = new Steam();
            if (steam.CellType != CellType.Steam) throw new Exception("Steam: CellType is incorrect");
            if (steam.Color != ConsoleColor.Gray) throw new Exception("Steam: Color is incorrect");
            if (steam.Representation != 'V') throw new Exception("Steam: Representation is incorrect");
            if (!steam.GoesUp) throw new Exception("Steam: GoesUp is incorrect");
            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        try
        {
            testNb++;
            var water = new Water();
            if (water.CellType != CellType.Water) throw new Exception("Water: CellType is incorrect");
            if (water.Color != ConsoleColor.DarkBlue) throw new Exception("Water: Color is incorrect");
            if (water.Representation != 'W') throw new Exception("Water: Representation is incorrect");
            if (water.GoesUp) throw new Exception("Water: GoesUp is incorrect");
            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        try
        {
            testNb++;
            var sand = new Sand();
            if (sand.CellType != CellType.Sand) throw new Exception("Sand: CellType is incorrect");
            if (sand.Color != ConsoleColor.Yellow) throw new Exception("Sand: Color is incorrect");
            if (sand.Representation != 'S') throw new Exception("Sand: Representation is incorrect");
            if (sand.GoesUp) throw new Exception("Sand: GoesUp is incorrect");
            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        #endregion

        #region MovableCellMethods

        try
        {
            testNb++;
            int weight = MovableCell.GetCellWeight(CellType.Steam);
            if (weight != 0) 
                throw new Exception($"GetCellWeight(CellType.Steam) returned {weight}, expected 0");
            weight = MovableCell.GetCellWeight(CellType.Fire);
            if (weight != 1) 
                throw new Exception($"GetCellWeight(CellType.Fire) returned {weight}, expected 1");
            weight = MovableCell.GetCellWeight(CellType.Water);
            if (weight != 2) 
                throw new Exception($"GetCellWeight(CellType.Water) returned {weight}, expected 2"); 
            weight = MovableCell.GetCellWeight(CellType.Sand);
            if (weight != 3) 
                throw new Exception($"GetCellWeight(CellType.Sand) returned {weight}, expected 3");
            weight = MovableCell.GetCellWeight(CellType.Rock);
            if (weight != int.MaxValue) 
                throw new Exception($"GetCellWeight(CellType.Rock) returned {weight}, expected int.MaxValue");
            weight = MovableCell.GetCellWeight(CellType.Glass);
            if (weight != int.MaxValue) 
                throw new Exception($"GetCellWeight(CellType.Glass) returned {weight}, expected int.MaxValue");
            weight = MovableCell.GetCellWeight(CellType.Wood);
            if (weight != int.MaxValue) 
                throw new Exception($"GetCellWeight(CellType.Wood) returned {weight}, expected int.MaxValue");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in GetCellWeight test: {e.Message}");
        }
        
        try
        {
            testNb++;
            Board board = new Board(2, 3);
            board.SetCell(CellType.Water, 0, 1);

            if (!((MovableCell)board.Cells[0, 1]!).TryMove(board, 0, 1, 1, 1) 
                || board.Cells[1,1] is not Water) 
                throw new Exception("TryMove: Water swap with nothing : move failed unexpectedly");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in TryMoveCell test: {e.Message}");
        }

        try
        {
            testNb++;
            Board board = new Board(2, 2);
            board.SetCell(CellType.Water, 0, 1);
            if (((MovableCell)board.Cells[0, 1]!).TryMove(board, 0, 1, 4, 4) 
                || board.Cells[0,1] is not Water) 
                throw new Exception("TryMove: out of bound move succeeded unexpectedly");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in TryMoveCell test: {e.Message}");
        }
        

        try
        {
            testNb+=2;
            Board board = new Board(2, 3);
            board.SetCell(CellType.Sand, 0, 0);
            board.SetCell(CellType.Water, 0, 1);


            if (((MovableCell)board.Cells[0, 1]!).TryMove(board, 0, 1, 0, 0)
                ||  board.Cells[0,0] is not Sand || board.Cells[0,1] is not Water) 
                throw new Exception("TryMoveCell : Water move/swaps with Sand : succeeded unexpectedly");
            if (!((MovableCell)board.Cells[0, 0]!).TryMove(board, 0, 0, 0, 1) 
                || board.Cells[0,0] is not Water || board.Cells[0,1] is not Sand) 
                throw new Exception("TryMoveCell : Water move/swaps with Sand : succeeded unexpectedly");

            testPassed+=2;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in TryMoveCell test: {e.Message}");
        }
        
        try
        {
            testNb+=2;
            Board board = new Board(2, 2);
            board.SetCell(CellType.Water, 0, 0);

            if (!((MovableCell)board.Cells[0, 0]!).MoveVertically(board, 0, 0) || board.Cells[1,0] is not Water ) 
                throw new Exception(" failed: new Board(2,2), called on Water(0,0)");

            if (((MovableCell)board.Cells[1, 0]!).MoveVertically(board, 1, 0) 
                || board.Cells[1,0] is not Water ) 
                throw new Exception(" succeeded unexpectedly: new Board(2,2), called on Water(1,0)");

            
            testPassed+=2;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in MoveVertically test: Vertical Movement {e.Message}");
        }
        
        
        try
        {
            testNb+=2;
            Board board = new Board(1, 3,2);
            board.SetCell(CellType.Water, 0, 1);

            if (((MovableCell)board.Cells[0, 1]!).MoveHorizontallyErratically(board, 0, 1))
                throw new Exception("Horizontal erratic move succeeded unexpectedly: new Board(1,3,2)");
            
            if (!((MovableCell)board.Cells[0, 1]!).MoveHorizontallyErratically(board, 0, 1)) 
                throw new Exception("Horizontal erratic move failed: new Board(1,3,2)");
            testPassed+=2;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in MoveHorizontallyErratically test: {e.Message}");
        }

        #endregion

        #region MovableCellMoveImplementation

        try
        
        {
            testNb++;
            Board board = new Board(3, 3);
            board.SetCell(CellType.Water, 1, 1);
            
            ((MovableCell)board.Cells[1, 1]!).Move(board, 1, 1);

            if (board.Cells[2, 1] is not Water)
                throw new Exception("Move method (Water): Cell did not move as expected");

            ((MovableCell)board.Cells[2, 1]!).Move(board, 2, 1);
            
            if (board.Cells[2, 1] is not Water)
                throw new Exception("Move method (Water): Cell did not move as expected");

            
            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in Move method (Water) test: {e.Message}");
        }

        try
        {
            testNb++;
            Board board = new Board(3, 3);
            board.SetCell(CellType.Sand, 1, 1);

            ((MovableCell)board.Cells[1, 1]!).Move(board, 1, 1);

            if (board.Cells[2, 1] is not Sand)
                throw new Exception("Move method (Sand): Cell did not move vertically as expected");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in Move method (Sand) test: {e.Message}");
        }
        
        try
        {
            testNb++;
            Board board = new Board(3, 3);
            board.SetCell(CellType.Steam, 1, 1);

            ((MovableCell)board.Cells[1, 1]!).Move(board, 1, 1);

            if (board.Cells[0, 1] is not Steam)
                throw new Exception("Move method (Steam): Cell did not move as expected");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in Move method (Steam) test: {e.Message}");
        }
        
        #endregion

        #region Board

        try
        {
            Board b = new Board(3, 2);
            b.SetCell(CellType.Water,1,1);
            b.SetCell(CellType.Sand,0,1);
            b.SetCell(CellType.Steam,1,0);

            b.NextBoard();
            b.NextBoard();
            if (Test.BoardToString(b) != "|V  W S|")
                throw new Exception("NextBoard: not the expected answer");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        try
        {
            Board b = new Board(3, 5,86);
            b.FillRandom();

            if (Test.BoardToString(b) != "|FRGGRFBFFGFFVSS|")
                throw new Exception("NextBoard: not the expected answer");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        #endregion
        
        Console.WriteLine($"{testPassed}/{testNb} tests passed on Intermediate.");
    }
    
}