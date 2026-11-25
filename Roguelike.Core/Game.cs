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
    private ActionLog log;
    private Item weapon;

    public Game(IBoardPrinter boardPrinter, IInputReader inputReader)
    {
        this.boardPrinter = boardPrinter;
        this.inputReader = inputReader;
        NewGame();
    }

    private void NewGame()
    {
        board = new Board();
        player = new Player(PickFreeCell());
        yurei = new Enemy(Cell.Yurei, PickFreeCell(), 11, 3);
        direction = default;
        item = new Item(Cell.HealingGourd, PickFreeCell());
        log = new ActionLog();
        weapon = PickRandomWeapon();
    }

    public void Start()
    {
        while (running)
        {
            boardPrinter.Print(board.board, player, yurei, item, log, weapon);

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
                log.Add($"You hit the Yurei for {player.Attack} damage");

                if (yurei.IsDead())
                {
                    log.Add("You defeated the Yurei!");
                }
                else
                {
                    player.TakeDamage(yurei.Attack);
                    log.Add($"The Yurei hits you for {yurei.Attack} damage");
                }
            }
            else if (board.board[nextPosition.Row, nextPosition.Col] != Cell.Wall)
            {
                player.MoveTo(direction);
            }

            if (!item.PickedUp && player.Position == item.Position)
            {
                item.PickUp();
                player.Heal(Item.Healing);
                log.Add($"You drink the gourd and heal up to {player.Hp} HP");
            }

            if (!weapon.PickedUp && player.Position == weapon.Position)
            {
                weapon.PickUp();
                var bonus = weapon.Type switch
                {
                    Cell.Katana => 4,
                    Cell.Naginata => 6,
                    Cell.Sai => 2,
                    _ => 0,
                };
                player.AddAttack(bonus);
                log.Add($"You picked up a {weapon.Type}!");
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
            var isTaken =
                (player != null && pos == player.Position)
                || (yurei != null && pos == yurei.Position);

            if (board.board[row, col] == Cell.Floor && !isTaken)
            {
                validPositions.Add(pos);
            }
        }
        return validPositions[random.Next(validPositions.Count)];
    }

    private Item PickRandomWeapon() =>
        random.Next(3) switch
        {
            0 => new Item(Cell.Naginata, PickFreeCell()),
            1 => new Item(Cell.Sai, PickFreeCell()),
            _ => new Item(Cell.Katana, PickFreeCell()),
        };
}
