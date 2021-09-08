using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileService.DTOs;
using FileService.Extensions;
using FileService.Models;
using FileService.Repositories;
using FileService.Interfaces;

namespace FileService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly FileContext _context;
        private readonly IFileExtensions _extensions;

        public FileController(FileContext context, IFileExtensions extensions)
        {
            _context = context;
            _extensions = extensions;
        }

        //GET /file
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReadFileDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ReadFileDTO>>> GetFiles()
        {
            var files = await _extensions.GetFiles();
            if(files == null)
            {
                return NotFound();
            }

            return Ok(files);
        }

        [HttpGet("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadFileDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadFileDTO>> GetFile(Guid id)
        {
            var file =  await _extensions.GetFile(id);

            if(file == null)
            {
                return NotFound();
            }

            return Ok(file);
        }

        // POST /user
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ReadFileDTO>> CreateFile(CreateFileDTO fileDTO)
        {
            File file = new()
            {
                UserId = fileDTO.UserId,
                Name = fileDTO.Name,
                Path = ""
            };

            var newFile = await _extensions.CreateFile(file);

            return CreatedAtAction(nameof(GetFile), new { id = file.Id }, newFile);
        }
    }
}
