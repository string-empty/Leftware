using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leftware.Infrastructure.Events;

public class EventBus : IEventBus
{
    private ILogger<EventBus> _logger;
    private readonly IServiceProvider _serviceProvider;

    public EventBus(ILogger<EventBus> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        foreach(var handler in _serviceProvider.GetServices<IEventHandler<TEvent>>())
            handler.Handle(@event);
    }
}