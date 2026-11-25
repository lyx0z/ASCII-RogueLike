namespace Roguelike.Core;

public class Item(Cell type, Position position)
{
    public Cell Type { get; } = type;
    public Position Position { get; } = position;
    public bool PickedUp { get; private set; }
    public static int Healing;

    public void PickUp()
    {
        switch (type)
        {
            case Cell.HealingGourd:
                Healing = 10;
                break;
            case Cell.Katana:
                Player.Attack += 4;
                break;
            case Cell.Naginata:
                Player.Attack += 6;
                break;
            case Cell.Sai:
                Player.Attack += 2;
                break;
        }

        PickedUp = true;
    }
}
