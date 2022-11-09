using Leftware.Infrastructure.InternalBus;
using Microsoft.AspNetCore.Mvc;

namespace Leftware.Plugin.Sample.Api;

[Route("ping")]
[ApiController]
public class SampleController : ControllerBase
{
    private readonly IMessageBus _messageBus;

    public SampleController(IMessageBus messageBus)
    {
        _messageBus = messageBus;
    }
    
    [HttpPost]
    public ActionResult Post(SampleRequest request)
    {
        _messageBus.Execute(request);
        return Ok();
    }
}