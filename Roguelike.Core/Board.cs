using System.Data;

namespace Roguelike.Core;

public class Board
{
    private const int Size = 32;
    private const int MinRoomSize = 4;
    private const int MaxRoomSize = 10;
    private readonly Random random = new();

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

        var room1 = RandomRoom();
        var room2 = RandomRoom();
        var room3 = RandomRoom();
        var room4 = RandomRoom();

        MakeHall(room1, room2);
        MakeHall(room2, room3);
        MakeHall(room3, room4);
    }

    private Position RandomRoom()
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

        return new Position(anchorRow + height / 2, anchorCol + width / 2);
    }

    private void MakeHall(Position fromRoom, Position toRoom)
    {
        var col = fromRoom.Col;
        var row = fromRoom.Row;
        while (col != toRoom.Col)
        {
            board[row, col] = Cell.Floor;
            if (col < toRoom.Col)
            {
                col++;
            }
            else
            {
                col--;
            }
        }

        while (row != toRoom.Row)
        {
            board[row, col] = Cell.Floor;
            if (row < toRoom.Row)
            {
                row++;
            }
            else
            {
                row--;
            }
        }
    }
}
