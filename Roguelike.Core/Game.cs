namespace Roguelike.Core;

public class Game
{
    private readonly IBoardPrinter boardPrinter;
    private readonly IInputReader inputReader;
    private readonly Player player = new(new Position(8, 8));
    private readonly Board board = new();
    private readonly Enemy yurei;
    private Direction direction;
    private bool running = true;

    public Game(IBoardPrinter boardPrinter, IInputReader inputReader)
    {
        this.boardPrinter = boardPrinter;
        this.inputReader = inputReader;
        yurei = new Enemy(Cell.Yurei, board.PickFreeCell(), 11, 50); //high attack to test death
    }

    public void Start()
    {
        while (running)
        {
            boardPrinter.Print(board.board, player, yurei);

            if (player.Hp <= 0)
            {
                GameOver();
                continue;
            }

            direction = inputReader.ReadDirection(direction);
            var nextPosition = player.NextPos(direction);

            if (!yurei.IsDead() && nextPosition == yurei.Position)
            {
                yurei.TakeDamage(player.Attack);
                player.TakeDamage(yurei.Attack);
            }
            else if (board.board[nextPosition.Row, nextPosition.Col] != Cell.Wall)
            {
                player.MoveTo(direction);
            }
        }
    }

    private void GameOver()
    {
        running = false;
        boardPrinter.PrintGameOver();
        if (inputReader.ReadKeyGameOver())
        {
            Start();
        }
    }
}
