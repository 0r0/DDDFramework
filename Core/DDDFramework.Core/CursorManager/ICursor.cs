using EventStore.Client;

namespace DDDFramework.Core.CursorManager;

public interface ICursor
{
    StreamPosition Position { get; }
    StreamPosition CurrentCursor();
    public void SetPosition(StreamPosition position);

}