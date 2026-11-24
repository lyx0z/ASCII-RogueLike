namespace Roguelike.Core;

public class Board
{
    private const int Size = 16;
    private readonly Random random = new();

    public Cell[,] board { get; } = new Cell[Size, Size];

    public Board()
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                var isBorder =
                    row == 0
                    || col == 0
                    || row == board.GetLength(0) - 1
                    || col == board.GetLength(1) - 1;
                board[row, col] = isBorder ? Cell.Wall : Cell.Floor;
            }
        }
    }
}
