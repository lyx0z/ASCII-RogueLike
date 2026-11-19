namespace Roguelike.CLI;

using Roguelike.Core;

public class ConsoleInputReader : IInputReader
{
    public Direction ReadDirection(Direction currentDirection)
    {
        var key = Console.ReadKey(intercept: true).Key;

        return key switch
        {
            ConsoleKey.W or ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.S or ConsoleKey.DownArrow => Direction.Down,
            ConsoleKey.A or ConsoleKey.LeftArrow => Direction.Left,
            ConsoleKey.D or ConsoleKey.RightArrow => Direction.Right,
            _ => currentDirection,
        };
    }
}
