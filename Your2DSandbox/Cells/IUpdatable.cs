using Your2DSandbox.Sim;

namespace Your2DSandbox.Cells;

public interface IUpdatable
{
    // Will be called on cell by the board, to evolve through time or react with other adjacent cell 
    // The coordinates are in bound
    public void Update(Board b, int h, int w);
}