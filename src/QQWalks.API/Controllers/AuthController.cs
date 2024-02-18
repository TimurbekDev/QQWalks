using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QQWalks.API.CustomActionFilters;
using QQWalks.Service.DTOs.Auths;
using QQWalks.Service.Interfaces;

namespace QQWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidateModel]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
    {
        var result = await this.authenticationService.RegisterAsync(registerRequestDTO);

        if (result)
            return Ok("User was registered");
        else
            return BadRequest("Something went wrong");
    }
    [HttpPost]
    [Route("Login")] 
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
    {
        var result = await this.authenticationService.LoginAsync(loginRequestDTO);

        if (result.Token.Length>0)
            return Ok(result);
        else
            return BadRequest("Username or Password incorrect");
    }
}
