using Core.Services.Playlist.Command.CreatePlaylist.DTOs;
using MediatR;

namespace Proiect_Teatru.Models.V1.In.Playlist;

public class CreatePlaylistRequestViewModel : IRequest<CreatePlaylistCommand>
{
    public string Name { get; set; }

    public CreatePlaylistCommand Convert()
    {
        return new CreatePlaylistCommand()
        {
            Name = Name
        };
    }
}