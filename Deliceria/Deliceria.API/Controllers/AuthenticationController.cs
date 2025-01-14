using System.IdentityModel.Tokens.Jwt;
using Deliceria.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deliceria.API.Controllers;

[Route("")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly Services.AuthenticationService _authenticationService;

    public AuthenticationController(Services.AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authenticationService.RegisterAsync(model);
          
        if (result.Succeeded)
        {
            return Ok(new { Message = "Registration successful." });
        }

        return BadRequest(new { result.Errors });
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = await _authenticationService.ValidateCredentialsAsync(model);
        if (user != null)
        {
            if (await _authenticationService.IsTwoFactorAuthenticationEnabledAsync(user)) {
                return Ok(new { UserId = user.Id }); //to be implemented
            }

            var token = _authenticationService.GenerateTokenAsync(user);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        return Unauthorized("Invalid email or password");
           
    }
}