using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_Teatru.Models.V1.In.Institution;
using Proiect_Teatru.Models.V1.Out.Institution;

namespace Proiect_Teatru.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class Institution(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult?> CreateInstitution(CreateInstitutionRequestViewModel request)
    {
        var ceva = await mediator.Send(request.Convert());
        return Ok(CreateInstitutionResponseViewModel.Convert(ceva));
    }
}