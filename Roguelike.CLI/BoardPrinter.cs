using System.Text;
using Roguelike.Core;

namespace Roguelike.CLI;

public class BoardPrinter : IBoardPrinter
{
    public void Print(Cell[,] board, Player player)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();

        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                if (player.Position.Row == row && player.Position.Col == col)
                    Console.Write(ChooseSymbol(Cell.Player));
                else
                    Console.Write(ChooseSymbol(board[row, col]));
            }

            Console.WriteLine();
        }
    }

    private static string ChooseSymbol(Cell cell) =>
        cell switch
        {
            Cell.Wall => "＃",
            Cell.Floor => "・",
            Cell.Player => "忍",
            _ => "？",
        };
}
