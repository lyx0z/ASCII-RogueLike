namespace Roguelike.Core;

public class Enemy(Cell name, Position startPosition, int hp, int attack)
{
    public Cell Name = name;
    public Position Position { get; private set; } = startPosition;
    private int Hp { get; set; } = hp;
    public int Attack { get; } = attack;

    public void TakeDamage(int amount)
    {
        Hp -= amount;
    }

    public bool IsDead()
    {
        return Hp <= 0;
    }
}
