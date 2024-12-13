using Your2DSandbox.Cells;
using Your2DSandbox.Cells.ImplementedCells;
using Your2DSandbox.Sim;

namespace Your2DSandbox.TestSuite;


public static class Easy
{
    public static void TestSuite()
    {
        int testPassed = 0;
        int testNb = 0;

        #region CellsRelated

        try
        {
            testNb++;
            var rock = new Rock();
            if (rock.CellType != CellType.Rock) throw new Exception("Rock: CellType is incorrect");
            if (rock.Color != ConsoleColor.DarkGray) throw new Exception("Rock: Color is incorrect");
            if (rock.Representation != 'R') throw new Exception("Rock: Representation is incorrect");
            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        try
        {
            testNb++;
            var wood = new Wood();
            if (wood.CellType != CellType.Wood) throw new Exception("Wood: CellType is incorrect");
            if (wood.Color != ConsoleColor.DarkYellow) throw new Exception("Wood: Color is incorrect");
            if (wood.Representation != 'B') throw new Exception("Wood: Representation is incorrect");
            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        try
        {
            testNb++;
            var glass = new Glass();
            if (glass.CellType != CellType.Glass) throw new Exception("Glass: CellType is incorrect");
            if (glass.Color != ConsoleColor.Blue) throw new Exception("Glass: Color is incorrect");
            if (glass.Representation != 'G') throw new Exception("Glass: Representation is incorrect");
            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        try
        {
            testNb+=2;
            if (Cell.CellFromCellType(CellType.Rock) is not Rock) 
                throw new Exception("CellFromCellType: Rock is not returned as expected");
            if (Cell.CellFromCellType(CellType.Wood) is not Wood) 
                throw new Exception("CellFromCellType: Wood is not returned as expected");
            if (Cell.CellFromCellType(CellType.Glass) is not Glass) 
                throw new Exception("CellFromCellType: Glass is not returned as expected");
            if (Cell.CellFromCellType(null) is not null) 
                throw new Exception("CellFromCellType: null is not returned as expected");
            testPassed+=2;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        

        #endregion

        #region BoardRelated

        try
        {
            testNb++;
            Board board = new Board(5, 10, 42);
            if (board.Height !=  5 || board.Width != 10)
                throw new Exception("Height and Width initialization error");
            
            if (board.Random.Next() != new Random(42).Next())
                throw new Exception("Random seed initialization error");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in Board constructor test: {e.Message}");
        }

        try
        {
            testNb++;
            Board board = new Board(3, 3);
            board.SetCell(CellType.Rock, 1, 1);

            if (board.Cells[1, 1] is not Rock)
                throw new Exception("SetCell method: CellType not set correctly");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in SetCell test: {e.Message}");
        }

        try
        {
            testNb++;
            Board board = new Board(2, 2);
            board.FillBoard(CellType.Glass);

            for (int h = 0; h < board.Height; h++)
            for (int w = 0; w < board.Width; w++)
                if (!(board.Cells[h, w] is Glass))
                    throw new Exception("FillBoard method: CellType not set correctly");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in FillBoard test: {e.Message}");
        }
        

        #endregion
        
        Console.WriteLine($"{testPassed}/{testNb} tests passed on Easy.");
    }
    
}