using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionFactory.WebApi.Controllers;

[ApiController]
[Route("api/bad")]
public class Bad : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Baddie(CancellationToken cancellationToken)
    {
        throw new Exception("You wrote poor code and I don't like it! BOOOO");
    }
}
