namespace Roguelike.Core;

public class Enemy(Cell name, Position startPosition)
{
    public Cell Name = name;
    public Position Position { get; private set; } = startPosition;
}
