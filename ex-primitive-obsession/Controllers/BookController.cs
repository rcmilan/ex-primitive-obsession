using Microsoft.AspNetCore.Mvc;

namespace ex_primitive_obsession.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok();
    }
}
