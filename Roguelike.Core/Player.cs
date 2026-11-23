namespace Roguelike.Core;

public class Player(Position startPosition)
{
    public Position Position { get; private set; } = startPosition;
    private int MaxHp => 30;
    private int hp = 30;
    public int Hp
    {
        get => hp;
        private set => hp = value > MaxHp ? MaxHp : value;
    }
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
    }
}
