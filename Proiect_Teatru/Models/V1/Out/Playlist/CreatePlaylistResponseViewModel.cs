using Core.Services.Playlist.Common;
using Proiect_Teatru.Models.Interfaces.Out;

namespace Proiect_Teatru.Models.V1.Out.Playlist;

public class CreatePlaylistResponseViewModel: IResponse<GetPlaylistByIdResponseViewModel,PlaylistDto>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<string> Music { get; set; }

    public static IResponse<GetPlaylistByIdResponseViewModel, PlaylistDto> Convert(PlaylistDto dto)
    {
        if (dto is null) return null;
        
        return new GetPlaylistByIdResponseViewModel()
        {
            Id = dto.Id,
            Name = dto.Name,
            Music = dto.Music
        };
    }
}