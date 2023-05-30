using Leftware.Infrastructure.InternalBus;
using Leftware.Plugin.Sample.Configuration;
using Microsoft.Extensions.Logging;

namespace Leftware.Plugin.Sample;

public class SampleRequestHandler : ICommandHandler<SampleRequest>
{
    private readonly ILogger<SampleRequestHandler> _logger;
    private readonly SampleSection _options;

    public SampleRequestHandler(
        SampleSection options,
        ILogger<SampleRequestHandler> logger)
    {
        _logger = logger;
        _options = options;
    }
    public void Execute(SampleRequest command)
    {
        _logger.LogInformation("{SampleId} executed!", command.SampleId);
        _logger.LogInformation("{SampleValue} is a configured json value!", _options.SampleField);
    }
}