using FastEndpoints;
using Leftware.Infrastructure.InternalBus;

namespace Leftware.Plugin.Sample.Api;

public class SampleEndpoint : Endpoint<SampleRequest>
{
	private readonly IMessageBus _messageBus;

	public SampleEndpoint(IMessageBus messageBus)
	{
		_messageBus = messageBus;
	}
	
	public override void Configure()
	{
		Post("/fast/ping");
		AllowAnonymous();
	}

	public override async Task HandleAsync(SampleRequest request, CancellationToken ct)
	{
		_messageBus.Execute(request);
	}
}