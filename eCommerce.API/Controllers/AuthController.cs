using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService) : ControllerBase
{
    [Route("register")] //POST api/auth/register
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest? request)
    {
        if(request is null)
            return BadRequest("Invalid registration request");
        
        //Call User service to handle the registration 
        AuthenticationResponse? response = await userService.Register(request);
        
        if(response is null || response.Success == false)
            return BadRequest("Registration failed");
        
        return Ok(response);
    }

    [Route("login")] //POST api/auth/login
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest? request)
    {
        if(request is null)
            return BadRequest("Invalid login request");
        
        //Call User service to handle the login
        AuthenticationResponse? response = await userService.Login(request);

        if (response is null || response.Success == false)
            return Unauthorized(response);
        
        return Ok(response);
    }
}