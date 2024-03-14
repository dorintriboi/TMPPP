using Application.Core.Managers.EventManager.Interfaces;
using Application.Core.Managers.EventManager.Models.In;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_Teatru.Models.V1.In.Event;
using Proiect_Teatru.Models.V1.Out.Event;

namespace Proiect_Teatru.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class Event(IEventManagementManager menager, IMediator mediator) : ControllerBase
{
    [HttpPost("puppetshow")]
    [Authorize]
    public async Task<IActionResult?> CreatePuppetShowEvent(EventRequestModel request)
    {
        var ceva = await menager.CreatePuppetShowEvent(request);
        return Ok(CreateEventResponseViewModel.Convert(ceva));
    }
    
    [HttpPost("educational")]
    [Authorize]
    public async Task<IActionResult?> CreateEducationalEvent(EventRequestModel request)
    {
        var ceva = await menager.CreateEducationalEvent(request);
        return Ok(CreateEventResponseViewModel.Convert(ceva));
    }
    
    [HttpPost("local")]
    [Authorize]
    public async Task<IActionResult?> CreateLocalEvent(EventRequestModel request)
    {
        var ceva = await menager.CreateLocalEvent(request);
        return Ok(CreateEventResponseViewModel.Convert(ceva));
    }
    
    [HttpPost("clowning")]
    [Authorize]
    public async Task<IActionResult?> CreateClowningEvent(EventRequestModel request)
    {
        var ceva = await menager.CreateClowningEvent(request);
        return Ok(CreateEventResponseViewModel.Convert(ceva));
    }
    
    [HttpPost("clone")]
    [Authorize]
    public async Task<IActionResult?> CreateClowningEvent(CloneEventRequestViewModel request)
    {
        return Ok(CloneEventResponseViewModel.Convert(await mediator.Send(request.Convert())));
    }
}