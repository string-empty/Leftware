using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leftware.Infrastructure.InternalBus;

public class MessageBus : IMessageBus
{
    private ILogger<MessageBus> _logger;
    private readonly IServiceProvider _serviceProvider;

    public MessageBus(ILogger<MessageBus> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
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