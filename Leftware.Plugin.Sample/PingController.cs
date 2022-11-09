using Microsoft.AspNetCore.Mvc;

namespace Leftware.Plugin.Sample;

[Route("ping")]
[ApiController]
public class PingController : ControllerBase
{
    [HttpGet]
    public ActionResult Ping() => Ok();
}