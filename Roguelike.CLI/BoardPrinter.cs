using System.Text;
using Roguelike.Core;

namespace Roguelike.CLI;

public class BoardPrinter : IBoardPrinter
{
    public void Print(Cell[,] board, Player player, Enemy enemy)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();

        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                var isHere = new Position(row, col);

                if (player.Position == isHere)
                {
                    Console.Write(ChooseSymbol(Cell.Player));
                }
                else if (enemy.Position == isHere && !enemy.IsDead())
                {
                    Console.Write(ChooseSymbol(enemy.Name));
                }
                else
                {
                    Console.Write(ChooseSymbol(board[row, col]));
                }
            }

            Console.WriteLine();
        }
        PrintStats(player);
    }

    private static string ChooseSymbol(Cell cell) =>
        cell switch
        {
            Cell.Wall => "＃",
            Cell.Floor => "・",
            Cell.Player => "忍",
            Cell.Yurei => "Ｙ",
            _ => "？",
        };

    private static void PrintStats(Player player)
    {
        Console.WriteLine(
            $"""
            ╔══════════════════════════════╗
            ║ STATS                        ║
            ╟──────────────────────────────╢
            ║ HP     {player.Hp, -22}║
            ║ Attack {player.Attack, -22}║
            ╚══════════════════════════════╝
            """
        );
    }
}
