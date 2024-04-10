using Core.Services.Playlist.Command.GetPlaylistById.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
}