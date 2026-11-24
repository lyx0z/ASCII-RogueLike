namespace Roguelike.Core;

public class Player(Position startPosition)
{
    public Position Position { get; private set; } = startPosition;
    private const int MaxHp = 30;

    public int Hp { get; private set; } = MaxHp;
    public int Attack => 5;

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
    }

    public void TakeDamage(int amount)
    {
        Hp -= amount;
    }

    public void Heal(int amount)
    {
        Hp += amount;
        if (Hp > MaxHp)
        {
            Hp = MaxHp;
        }
    }
}
