using Roguelike.Core;

namespace Roguelike.CLI;

internal static class Program
{
    private static Game game = new(new BoardPrinter());

    public static void Main()
    {
        game.Start();
    }
}
