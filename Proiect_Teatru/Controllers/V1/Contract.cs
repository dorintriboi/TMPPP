using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_Teatru.Models.V1.In.Contract;
using Proiect_Teatru.Models.V1.Out.Contract;

namespace Proiect_Teatru.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class Contract(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<IActionResult?> CreateContract(CreateContractRequestViewModel request)
    {
        var ceva = await mediator.Send(request.Convert());
        return Ok(CreateContractResponseViewModel.Convert(ceva));
    }
}