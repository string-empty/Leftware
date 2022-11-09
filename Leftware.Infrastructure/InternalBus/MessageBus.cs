using Microsoft.Extensions.DependencyInjection;

namespace Leftware.Infrastructure.InternalBus;

public class MessageBus : IMessageBus
{
    private readonly IServiceProvider _serviceProvider;

    public MessageBus(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        foreach(var handler in _serviceProvider.GetServices<IEventHandler<TEvent>>())
            handler.Handle(@event);
    }

    public void Execute<TCommand>(TCommand command) where TCommand : ICommand
    {
        _serviceProvider.GetServices<ICommandHandler<TCommand>>().Single().Execute(command);
    }
}