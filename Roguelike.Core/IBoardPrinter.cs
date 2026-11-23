namespace Roguelike.Core;

public interface IBoardPrinter
{
    void Print(Cell[,] board, Player player, Enemy enemy, Item item);
    void PrintGameOver();
}
