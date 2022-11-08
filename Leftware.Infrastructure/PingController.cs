using Microsoft.AspNetCore.Mvc;

namespace Leftware.Infrastructure;

[Route("ping")]
[ApiController]
public class PingController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Ping() => Ok();
}