using Core.Services.Playlist.Command.AssignePlaylistToPlaylist.DTOs;
using Proiect_Teatru.Models.Interfaces.In;

namespace Proiect_Teatru.Models.V1.In.Playlist;

public class AssignPlaylistToPlaylistRequestViewModel: IRequest<AssignPlaylistToPlaylistCommand>
{
    public string PlaylistId { get; set; }
    public string ReferencePlaylistId { get; set; }

    public AssignPlaylistToPlaylistCommand Convert()
    {
        return new AssignPlaylistToPlaylistCommand()
        {
            PlaylistId = PlaylistId,
            ReferencePlaylistId = ReferencePlaylistId
        };
    }
}