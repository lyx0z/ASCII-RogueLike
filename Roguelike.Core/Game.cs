namespace Roguelike.Core;

public class Game(IBoardPrinter boardPrinter)
{
    public Player player = new(new Position(8, 8));
    private Board board = new();

    public void Start()
    {
        board.board[player.Position.Row, player.Position.Col] = Cell.Player;
        boardPrinter.Print(board.board, player);
    }
}
