namespace Roguelike.Core;

public class Game(IBoardPrinter boardPrinter, IInputReader inputReader)
{
    private Player player = new(new Position(8, 8));
    private Board board = new();
    private Direction direction;

    public void Start()
    {
        while (true)
        {
            boardPrinter.Print(board.board, player);

            direction = inputReader.ReadDirection(direction);
            player.MoveTo(direction);
        }
    }
}
