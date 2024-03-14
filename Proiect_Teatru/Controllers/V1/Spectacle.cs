using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_Teatru.Models.V1.In.Spectacle;
using Proiect_Teatru.Models.V1.Out.Spectacle;

namespace Proiect_Teatru.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class Spectacle(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult?> CreateSpectacle(CreateSpectacleRequestViewModel request)
    {
        var ceva = await mediator.Send(request.Convert());
        return Ok(CreateSpectacleResponseViewModel.Convert(ceva));
    }
}