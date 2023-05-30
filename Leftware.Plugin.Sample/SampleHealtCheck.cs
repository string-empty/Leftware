using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Leftware.Plugin.Sample;

public class SampleHealtCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = new())
    {
        return Task.FromResult( HealthCheckResult.Healthy("A healthy result."));
    }
}