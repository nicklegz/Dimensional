using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace file_service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{ 
    [AllowAnonymous]
    [Produces("application/json")]
    [HttpGet]
    public async Task<IActionResult> GetFilesForUser()
    {
        return Ok();
    }
}