using file_service.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace file_service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IFileRepository _fileRepository;

    public FileController(IHttpContextAccessor httpContextAccessor, IFileRepository fileRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _fileRepository = fileRepository;
    }

    [Authorize]
    [Produces("application/json")]
    [HttpGet]
    public async Task<IActionResult> GetListFilesForUser()
    {
        try
        {
            string username = _httpContextAccessor.HttpContext.User.Identity.Name;
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest();
            }

            var listOfFiles = await _fileRepository.GetListFilesAsync(username);

            return Ok(listOfFiles);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateFile()
    {
        IFormFileCollection files = _httpContextAccessor.HttpContext?.Request?.Form?.Files;
        if (files == null)
        {
            return BadRequest("File was not included in request.");
        }

        for(int i = 0; i < files.Count; i++)
        {
            IFormFile file = files[i];
            if (file != null)
            {

            }
        }

    }
}