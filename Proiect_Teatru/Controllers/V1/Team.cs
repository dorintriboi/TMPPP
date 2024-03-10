using MediatR;
using Microsoft.AspNetCore.Mvc;
using Proiect_Teatru.Models.V1.In.Team;
using Proiect_Teatru.Models.V1.Out.Team;

namespace Proiect_Teatru.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class Team(IMediator mediator) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult?> CreateTeam(CreateTeamRequestViewModel request)
    {
        var ceva = await mediator.Send(request.Convert());
        return Ok(CreateTeamResponseViewModel.Convert(ceva));
    }
}