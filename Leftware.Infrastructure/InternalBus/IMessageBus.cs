namespace Leftware.Infrastructure.InternalBus;

public interface IMessageBus
{
    void Publish<TEvent>(TEvent theEvent) where TEvent : IEvent;
    void Execute<TCommand>(TCommand command) where TCommand : ICommand;
}