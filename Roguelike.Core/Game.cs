namespace Roguelike.Core;

public class Game
{
    private IBoardPrinter boardPrinter;
    private IInputReader inputReader;
    private Player player = new(new Position(8, 8));
    private Board board = new();
    private Enemy goblin;
    private Direction direction;

    public Game(IBoardPrinter boardPrinter, IInputReader inputReader)
    {
        this.boardPrinter = boardPrinter;
        this.inputReader = inputReader;
        goblin = new Enemy(Cell.Goblin, board.PickFreeCell());
    }

    public void Start()
    {
        while (true)
        {
            boardPrinter.Print(board.board, player, goblin);

            direction = inputReader.ReadDirection(direction);
            var nextPosition = player.NextPos(direction);
            if (board.board[nextPosition.Row, nextPosition.Col] != Cell.Wall)
            {
                player.MoveTo(direction);
            }
        }
    }
}
