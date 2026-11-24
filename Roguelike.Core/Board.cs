namespace Roguelike.Core;

public class Board
{
    private const int Size = 20;
    private const int MinRoomSize = 4;
    private readonly Random random = new();
    private const int MaxRoomSize = 10;

    public Cell[,] board { get; } = new Cell[Size, Size];

    public Board()
    {
        for (var row = 0; row < Size; row++)
        {
            for (var col = 0; col < Size; col++)
            {
                board[row, col] = Cell.Wall;
            }
        }

        RandomRoom();
        RandomRoom();
        RandomRoom();
    }

    private void RandomRoom()
    {
        var height = random.Next(MinRoomSize, MaxRoomSize);
        var width = random.Next(MinRoomSize, MaxRoomSize);

        var anchorRow = random.Next(1, Size - height);
        var anchorCol = random.Next(1, Size - width);

        for (var row = anchorRow; row < anchorRow + height; row++)
        {
            for (var col = anchorCol; col < anchorCol + width; col++)
            {
                board[row, col] = Cell.Floor;
            }
        }
    }
}
