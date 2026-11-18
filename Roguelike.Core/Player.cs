namespace Roguelike.Core;

public class Player(Position startPosition)
{
    public Position Position { get; private set; } = startPosition;
}
