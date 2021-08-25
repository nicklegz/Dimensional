using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.DTOs;
using UserService.Extensions;
using UserService.Models;
using UserService.Repositories;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly IUserExtensions _extensions;

        public UserController(UserContext context, IUserExtensions extensions)
        {
            _context = context;
            _extensions = extensions;
        }

        //GET /user
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReadUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ReadUserDTO>>> GetUsers()
        {
            var users = await _extensions.GetUsers();
            if(users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadUserDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadUserDTO>> GetUser(Guid id)
        {
            var user =  await _extensions.GetUser(id);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST /user
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ReadUserDTO>> CreateUser(CreateUserDTO userDTO)
        {
            User user = new()
            {
                Username = userDTO.Username,
                Password = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                OrganizationName = userDTO.OrganizationName
            };

            var newUser = await _extensions.CreateUser(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, newUser);
        }

        // PUT /user/{id}
        [HttpPut("/{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, UpdateUserDTO userDTO)
        {
            var existingUser = await _context.Users.Where(user => user.Id == id).SingleOrDefaultAsync();

            if(existingUser is null)
            {
                return NotFound();
            }

            User updatedUser = existingUser with
            {
                Username = userDTO.Username,
                Password = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                OrganizationName = userDTO.OrganizationName
            };

            _extensions.UpdateUser(updatedUser);
            return NoContent();
        }
    }
}
