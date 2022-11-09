using Leftware.Infrastructure.InternalBus;

namespace Leftware.Plugin.Sample;

public record SampleRequest(string SampleId) : ICommand;