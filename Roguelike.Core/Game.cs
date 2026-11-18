namespace Roguelike.Core;

public class Game(IBoardPrinter boardPrinter)
{
    public void Start()
    {
        var board = new Board();
        boardPrinter.Print(board.board);
    }
}
