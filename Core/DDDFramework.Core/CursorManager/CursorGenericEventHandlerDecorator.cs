using Aggregate;
using DDDFramework.Core.Application.Contracts;

namespace DDDFramework.Core.CursorManager;

public class CursorGenericEventHandlerDecorator<T> :IEventHandler<T> where T : IEvent
{
    private readonly IEventHandler<T> _eventHandler;

    public CursorGenericEventHandlerDecorator(IEventHandler<T> eventHandler)
    {
        _eventHandler = eventHandler;
    }

    public async Task Handle(T @event)
    {
        //todo! implement commented functionality in future
        //transaction add current Cursor
        await _eventHandler.Handle(@event);
        // finish transaction
    }
}