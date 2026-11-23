namespace Roguelike.Core;

public class Item(Cell type, Position position)
{
    public Cell Type { get; } = type;
    public Position Position { get; } = position;
    public bool PickedUp { get; private set; }
    public int Healing { get; } = 10;

    public void PickUp()
    {
        PickedUp = true;
    }
}
