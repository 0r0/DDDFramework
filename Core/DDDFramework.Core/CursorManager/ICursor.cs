using EventStore.Client;

namespace DDDFramework.Core.CursorManager;

public interface ICursor
{
    Position Position { get; }
    Position CurrentCursor();
}