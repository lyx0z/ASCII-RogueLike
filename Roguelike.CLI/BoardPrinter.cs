using System.Text;
using Roguelike.Core;

namespace Roguelike.CLI;

public class BoardPrinter : IBoardPrinter
{
    public void Print(Cell[,] board, Player player, Enemy enemy, Item item)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;

        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                var isHere = new Position(row, col);

                if (player.Position == isHere)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(ChooseSymbol(Cell.Player));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (enemy.Position == isHere && !enemy.IsDead())
                {
                    Console.Write(ChooseSymbol(enemy.Name));
                }
                else if (item.Position == isHere && !item.PickedUp)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(ChooseSymbol(item.Type));
                    Console.ForegroundColor = ConsoleColor.White;
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
            Cell.HealingGourd => "！",
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

    public void PrintGameOver()
    {
        var gameOverText = """
            ████████████████████████████
                  ████
                 ████            ████
                ███████████      ████     ▄██
               ████     ████     ████  ▄███▀
              ████  ▄   ████     ████▄███▀
             ████  ▀██▄████      ██████▀
            ███▀     █████       ████
                    ████         ████        ██
                   ████          ████        ██
                 ▄████           ██████████████
               ▄███▀

                  D   E   A   T   H
            """;
        Console.ForegroundColor = ConsoleColor.DarkRed;
        for (var i = 0; i < 4; i++)
        {
            Console.Clear();
            Console.WriteLine(gameOverText);
            Thread.Sleep(400);

            Console.Clear();
            Thread.Sleep(200);
        }
        Console.WriteLine(gameOverText);
        Console.WriteLine("   Press SPACE to continue");
        Console.ResetColor();
    }
}
