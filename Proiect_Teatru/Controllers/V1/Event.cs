using Application.Core.Managers.EventManager.Interfaces;
using Application.Core.Managers.EventManager.Models.In;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_Teatru.Models.V1.Out.Event;

namespace Proiect_Teatru.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class Event(IEventManagementManager menager) : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult?> CreatePuppetShowEvent(EventRequestModel request)
    {
        var ceva = await menager.CreatePuppetShowEvent(request);
        return Ok(CreateEventResponseViewModel.Convert(ceva));
    }
}