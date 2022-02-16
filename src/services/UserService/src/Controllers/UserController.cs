using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Repositories.Interfaces;
using Services;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserController(IUserRepository userRepository, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _httpContextAccessor = httpContextAccessor;
    }
    
    [AllowAnonymous]
    [Produces("application/json")]
    [HttpPost("/sign-in")]
    public async Task<IActionResult> SignIn([FromBody] User user)
    {
        User existingUser = await _userRepository.GetUserByUsernameAsync(user.Username);
        if(existingUser == null)
        {
            return NotFound(String.Format($"Username {0} does not exist.", user.Username));
        }

        PasswordVerificationResult isValidPassword = PasswordExtensions.IsValidPassword(user);
        switch(isValidPassword)
        {
            case PasswordVerificationResult.Failed:
                return Unauthorized("Invalid password. Please try again.");
            
            case PasswordVerificationResult.SuccessRehashNeeded:
                PasswordExtensions.HashUserPassword(user);
                await _userRepository.UpdateAsync(user);
                break;
            
            case PasswordVerificationResult.Success:
                break;
        }

        string accessToken = _tokenService.GenerateToken(user);
        TokenResponse tokenResponse = new TokenResponse
        {
            access_token = accessToken,
            token_type = "Bearer",
            expires_in = 3600
        };

        return Ok(tokenResponse);
    }

    [AllowAnonymous]
    [Produces("application/json")]
    [HttpPost("/sign-up")]
    public async Task<IActionResult> SignUp([FromBody] User user)
    {
        User existingUser = await _userRepository.GetUserByUsernameAsync(user.Username);
        if(existingUser != null)
        {
            return Conflict();
        }

        PasswordExtensions.HashUserPassword(user);
        CreateUserResponse result = await _userRepository.CreateAsync(user);
        return CreatedAtAction(nameof(SignUp), result);
    }

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> DeleteUser()
    {
        string username = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
        if(string.IsNullOrWhiteSpace(username))
        {
            return BadRequest();
        }

        User existingUser = await _userRepository.GetUserByUsernameAsync(username);
        if (existingUser == null)
        {
            return NotFound();
        }

        await _userRepository.DeleteAsync(existingUser);

        //need to delete all files for this user


        return Ok();
    }
}