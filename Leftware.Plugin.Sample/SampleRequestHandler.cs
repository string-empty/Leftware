using Leftware.Infrastructure.InternalBus;
using Microsoft.Extensions.Logging;

namespace Leftware.Plugin.Sample;

public class SampleRequestHandler : ICommandHandler<SampleRequest>
{
    private readonly ILogger<SampleRequestHandler> _logger;

    public SampleRequestHandler(ILogger<SampleRequestHandler> logger)
    {
        _logger = logger;
    }
    public void Execute(SampleRequest command)
    {
        _logger.LogInformation("{SampleId} executed!", command.SampleId);
    }
}