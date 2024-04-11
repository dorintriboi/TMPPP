using Core.Services.Music.Command.AssigneMusicToPlaylist.DTOs;
using MediatR;

namespace Proiect_Teatru.Models.V1.In.Music;

public class AssignMusicToPlaylistRequestViewModel: IRequest<AssignMusicToPlaylistCommand>
{
    public string MusicId { get; set; }
    public string PlaylistId { get; set; }

    public AssignMusicToPlaylistCommand Convert()
    {
        return new AssignMusicToPlaylistCommand()
        {
            MusicId = MusicId,
            PlaylistId = PlaylistId
        };
    }
}