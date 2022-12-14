namespace Leftware.Infrastructure.InternalBus;

public interface IEventHandler<in TEvent> where TEvent : IEvent
{
    void Handle(TEvent @event);
}