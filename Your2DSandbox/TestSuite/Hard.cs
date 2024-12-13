using Your2DSandbox.Cells;
using Your2DSandbox.Cells.ImplementedCells;
using Your2DSandbox.Sim;

namespace Your2DSandbox.TestSuite;

public static class Hard
{
    public static void TestSuite()
    {
        int testPassed = 0;
        int testNb = 0;

        #region IUpdatable

        try
        {
            testNb++;
            Board board = new Board(3, 3);
            Fire fireCell = new Fire();
            board.Cells[1, 1] = fireCell;

            fireCell.Update(board, 1, 1);

            if (board.Cells[1, 1] is null)
                throw new Exception("Update method (Fire): Cell burned out ");

            for (int i = 0; i < 100; i++)
            {
                fireCell.Update(board, 1, 1);
            }
            
            if (board.Cells[1, 1] is not  null)
                throw new Exception("Update method (Fire): Cell did not burn out ");
            
            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in Update method (Fire) test: {e.Message}");
        }

        // Test for Update method for Steam
        try
        {
            testNb++;
            Board board = new Board(3, 3);
            Steam steamCell = new Steam();
            board.Cells[1, 1] = steamCell;
            steamCell.Update(board, 1, 1);

            if (board.Cells[1, 1] is Water)
                throw new Exception("Update method (Steam): Cell condensed to Water ");

            for (int i = 0; i < 50; i++)
            {
                steamCell.Update(board, 1, 1);
            }
            
            if (board.Cells[1, 1] is not Water)
                throw new Exception("Update method (Steam): Cell did not condense to Water ");

            
            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in Update method (Steam) test: {e.Message}");
        }

        #endregion


        #region IBurnable

        // Test for Burn method for Wood
        try
        {
            testNb++;
            Board board = new Board(3, 3);
            board.SetCell(CellType.Wood, 1, 1);

            bool burned = ((IBurnable)board.Cells[1, 1]!).Burn(board, 1, 1);

            if (!(board.Cells[1, 1] is Fire))
                throw new Exception("Burn method (Wood): Cell not burned as expected");

            if (burned)
                throw new Exception("Burn method (Wood): Expected return value is false");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in Burn method (Wood) test: {e.Message}");
        }

        // Test for Burn method for Water
        try
        {
            testNb++;
            Board board = new Board(3, 3);
            board.SetCell(CellType.Water, 1, 1);

            bool evaporated = ((IBurnable)board.Cells[1, 1]!).Burn(board, 1, 1);

            if (!(board.Cells[1, 1] is Steam))
                throw new Exception("Burn method (Water): Cell not evaporated as expected");

            if (!evaporated)
                throw new Exception("Burn method (Water): Expected return value is true");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in Burn method (Water) test: {e.Message}");
        }

        // Test for Burn method for Steam
        try
        {
            testNb++;
            Board board = new Board(3, 3);
            board.SetCell(CellType.Steam, 1, 1);

            bool condensation = ((IBurnable)board.Cells[1, 1]!).Burn(board, 1, 1);

            if (((Steam)board.Cells[1, 1]!).CondensationTimer != 50)
                throw new Exception("Burn method (Steam): Condensation timer not set correctly");

            if (condensation)
                throw new Exception("Burn method (Steam): Expected return value is false");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in Burn method (Steam) test: {e.Message}");
        }

        // Test for Burn method for Sand
        try
        {
            testNb++;
            Board board = new Board(3, 3);
            board.SetCell(CellType.Sand, 1, 1);

            bool converted = ((IBurnable)board.Cells[1, 1]!).Burn(board, 1, 1);

            if (!(board.Cells[1, 1] is Glass))
                throw new Exception("Burn method (Sand): Cell not converted to Glass as expected");

            if (!converted)
                throw new Exception("Burn method (Sand): Expected return value is true");

            testPassed++;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in Burn method (Sand) test: {e.Message}");
        }

        #endregion
        
        try
        {
            string[] steps = new[]
            {
                "|BFWSWVVFFRVWSRFVFWVBSGSSWFGRRGGGFGGSFBFSWWVRRBGFVBBGWWVBBRGVVVBVRVFWS" +
                "BRRFBRVSRSGVWSBWRFSRWFFFGBBGRRSVBBWBWSVSRSBVRGWFGWGRWSVVBBFRFGSRGRSVGRR|",
                "|FV WFVFVFRVF RFVVFVBWGVSG GRRGGGVGGV FGVVVSRRFGV BBGFVSBFRG SWBVR FFWBR" +
                "RVFRVSRSGVVWBWRVVRF FVGBBGRRWWBBVBVFGFRGF RGVVGSGRWSSWBFGRSGSRGRS GRR|",
                "|V WFVFVFVRVFVRFVVFVBVGVSG GRRGGGFGG FVGVV WRRFGFVBBGVSFFVRG VVBVR VVVFRR" +
                "VVR GRWGSSVBVRVFRF F GBBGRRSWBBWB  G RG  RGVVGSGRWSSWFFGRSGGRGRS GRR|",
                "|VVVV FVVFRVFFRFVFFVBVGWWG GRRGGGVGGVVVGVVGVRRFGFVFBGVVFF RG  VBVRVVFFF" +
                "RRVSR GRWGWS B RVVRV F GBBGRRSSBBWBWFG RG  RGVVGSGRWSSF  GRSGGRGRS GRR|",
                "|VVVV FVVFRVFFRFFVVFBVGVWGFGRRGGGVGGFVVGVVGWRRVGVFFFGVVFV RG  VBVRVVFFFRR" +
                "  R GRWGWS B R VR VVGGBBGRRSWBBFF FG RG  RGVVGSGRSSGV  GRSGGRGRS GRR|"
            };
            
            Board b =new Board(7, 20, 78);
            b.FillRandom();
            for (int i = 0; i < 5; i++)
            {
                testNb++;
                if (Test.BoardToString(b) != steps[i])
                    throw new Exception("Run Simulation: Cell Behaviour not correct");
                b.NextBoard();
                testPassed++;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine($"{testPassed}/{testNb} tests passed on Hard.");
    }
}