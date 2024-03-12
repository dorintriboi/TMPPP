using MediatR;
using Microsoft.AspNetCore.Mvc;
using Proiect_Teatru.Models.V1.In.Account;


namespace Proiect_Teatru.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class Account(IMediator mediator) : ControllerBase
{
    [HttpPost("registration")]
    public async Task<IActionResult> Register(RegisterUserRequestViewModel registerRequest)
    {
        try
        {
            await mediator.Send(registerRequest.Convert());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestViewModel loginRequest)
    {
        try
        {
            var token = await mediator.Send(loginRequest.Convert());

            return Ok(token);
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }
}