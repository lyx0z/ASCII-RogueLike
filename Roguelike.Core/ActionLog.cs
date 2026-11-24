namespace Roguelike.Core;

public class ActionLog
{
    private const int MaxMessages = 5;

    public List<string> Messages { get; } = [];

    public void Add(string message)
    {
        Messages.Add(message);
        if (Messages.Count > MaxMessages)
        {
            Messages.RemoveAt(0);
        }
    }
}
