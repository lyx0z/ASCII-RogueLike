namespace Roguelike.Core;

public interface IBoardPrinter
{
    void Print(
        Cell[,] board,
        Player player,
        Enemy enemy,
        Item healingGourd,
        ActionLog log,
        Item weapon
    );
    void PrintGameOver();
}
