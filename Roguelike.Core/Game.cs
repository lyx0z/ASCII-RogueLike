namespace Roguelike.Core;

public class Game
{
    private readonly IBoardPrinter boardPrinter;
    private readonly IInputReader inputReader;
    private Player player;
    private Board board;
    private Enemy yurei;
    private Direction direction;
    private bool running = true;
    private Item item;
    private readonly Random random = new();

    public Game(IBoardPrinter boardPrinter, IInputReader inputReader)
    {
        this.boardPrinter = boardPrinter;
        this.inputReader = inputReader;
        NewGame();
    }

    private void NewGame()
    {
        player = new Player(new Position(8, 8));
        board = new Board();
        yurei = new Enemy(Cell.Yurei, PickFreeCell(), 11, 4);
        direction = default;
        item = new Item(Cell.HealingGourd, PickFreeCell());
    }

    public void Start()
    {
        while (running)
        {
            boardPrinter.Print(board.board, player, yurei, item);

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

            if (!item.PickedUp && player.Position == item.Position)
            {
                player.Heal(item.Healing);
                item.PickUp();
            }
        }
    }

    private void GameOver()
    {
        boardPrinter.PrintGameOver();
        if (inputReader.ReadKeyGameOver())
        {
            NewGame();
        }
        else
        {
            running = false;
        }
    }

    private Position PickFreeCell()
    {
        var validPositions = new List<Position>();
        for (var row = 0; row < board.board.GetLength(0); row++)
        for (var col = 0; col < board.board.GetLength(1); col++)
        {
            var pos = new Position(row, col);
            var isTaken = pos == player.Position || (yurei != null && pos == yurei.Position);

            if (board.board[row, col] == Cell.Floor && !isTaken)
            {
                validPositions.Add(pos);
            }
        }
        return validPositions[random.Next(validPositions.Count)];
    }
}
