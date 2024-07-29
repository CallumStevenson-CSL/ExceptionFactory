using Microsoft.AspNetCore.Mvc;

namespace ExceptionFactory.WebApi.Controllers;

[ApiController]
[Route("api/Good")]
public class Good : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Goodie(CancellationToken cancellationToken)
    {
        return new OkObjectResult("All OK!");
    }
}
