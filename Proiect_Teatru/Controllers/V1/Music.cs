using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_Teatru.Models.V1.In.Music;
using Proiect_Teatru.Models.V1.Out.Music;

namespace Proiect_Teatru.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class Music(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<IActionResult?> CreateMusic(CreateMusicRequestViewModel request)
    {
        var ceva = await mediator.Send(request.Convert());
        return Ok(CreateMusicResponseViewModel.Convert(ceva));
    }
    
    [Authorize]
    [HttpPost("playlist")]
    public async Task<IActionResult?> AssignMusicToPlaylist(AssignMusicToPlaylistRequestViewModel request)
    {
        await mediator.Send(request.Convert());
        return Ok();
    }
}