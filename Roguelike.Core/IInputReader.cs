namespace Roguelike.Core;

public interface IInputReader
{
    Direction ReadDirection(Direction currentDirection);
    bool ReadKeyGameOver();
}
