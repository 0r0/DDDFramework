using EventStore.Client;

namespace DDDFramework.Core.CursorManager;

public class Cursor : ICursor
{
    public Position Position { get; private set; } = Position.Start;

    public Position CurrentCursor()
    {
        return Position;
    }

    public void SetPosition(Position position)
    {
        Position = position;
    }
}