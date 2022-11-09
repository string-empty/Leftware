using Microsoft.AspNetCore.Mvc;

namespace Leftware.Plugin.Sample.Api;

[Route("ping")]
[ApiController]
public class PingController : ControllerBase
{
    private readonly ISampleRegistration _sampleRegistration;

    public PingController(ISampleRegistration sampleRegistration)
    {
        _sampleRegistration = sampleRegistration;
    }
    
    [HttpGet]
    public ActionResult<string> Ping() => Ok(_sampleRegistration.Greeting);
}