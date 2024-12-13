using Your2DSandbox.Sim;

namespace Your2DSandbox.Cells;

public interface IBurnable
{
    // Trigger the burn behaviour of cel; it returns true if the fire that caused the burn needs to be extinguished
    // The coordinates are in bound
    public bool Burn(Board b, int h, int w);
}