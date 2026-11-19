namespace Roguelike.Core;

public class Player(Position startPosition)
{
    public Position Position { get; private set; } = startPosition;

    public Position NextPos(Direction direction) =>
        direction switch
        {
            Direction.Up => Position with { Row = Position.Row - 1 },
            Direction.Down => Position with { Row = Position.Row + 1 },
            Direction.Left => Position with { Col = Position.Col - 1 },
            Direction.Right => Position with { Col = Position.Col + 1 },
            _ => Position,
        };

    public void MoveTo(Direction direction)
    {
        Position = NextPos(direction);
        ;
    }
}
