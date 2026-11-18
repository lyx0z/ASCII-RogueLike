namespace Roguelike.Core;

public class Game(IBoardPrinter boardPrinter)
{
    public void Start()
    {
        var boardc = new Board();
        boardPrinter.Print(boardc.board);
    }
}
