using EventStore.Client;

namespace DDDFramework.Core.CursorManager;

public class Cursor : ICursor
{
    public StreamPosition Position { get; private set; } = StreamPosition.Start;

    public StreamPosition CurrentCursor()
    {
        return Position;
    }

    public void SetPosition(StreamPosition position)
    {
        Position = position;
    }
}