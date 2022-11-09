using Microsoft.AspNetCore.Mvc;

namespace Leftware.Plugin.Sample.Api;

[Route("ping")]
[ApiController]
public class PingController : ControllerBase
{
    [HttpGet]
    public ActionResult Ping() => Ok();
}