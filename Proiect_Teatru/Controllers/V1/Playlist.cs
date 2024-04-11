using Core.Services.Playlist.Queries.GetPlaylistById.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_Teatru.Models.V1.In.Playlist;
using Proiect_Teatru.Models.V1.Out.Playlist;

namespace Proiect_Teatru.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class Playlist(IMediator mediator) : ControllerBase
{
    [HttpGet("{playlistId}")]
    [Authorize]
    public async Task<IActionResult?> GetPLaylistMusic(string playlistId)
    {
        var ceva = await mediator.Send(new GetPlaylistByIdQuery(){PlaylistId = playlistId});
        return Ok(GetPlaylistByIdResponseViewModel.Convert(ceva));
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult?> CreateMusic(CreatePlaylistRequestViewModel request)
    {
        var ceva = await mediator.Send(request.Convert());
        return Ok(CreatePlaylistResponseViewModel.Convert(ceva));
    }
    
    [Authorize]
    [HttpPost("playlist")]
    public async Task<IActionResult?> AssignPlaylistToPlaylist(AssignPlaylistToPlaylistRequestViewModel request)
    {
        await mediator.Send(request.Convert());
        return Ok();
    }
}