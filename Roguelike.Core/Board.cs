using System.Reflection;

namespace Roguelike.Core;

public class Board
{
    private const int Size = 16;
    private readonly Random random = new();

    public Cell[,] board = new Cell[Size, Size];

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

    public Position PickFreeCell()
    {
        var validPositions = new List<Position>();
        for (var row = 0; row < board.GetLength(0); row++)
        for (var col = 0; col < board.GetLength(1); col++)
        {
            var pos = new Position(row, col);
            if (board[row, col] == Cell.Floor)
            {
                validPositions.Add(pos);
            }
        }
        return validPositions[random.Next(validPositions.Count)];
    }
}
