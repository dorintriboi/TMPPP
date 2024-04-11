using Core.Services.Music.Common;
using Proiect_Teatru.Models.Interfaces.Out;

namespace Proiect_Teatru.Models.V1.Out.Music;

public class CreateMusicResponseViewModel: IResponse<CreateMusicResponseViewModel,MusicDto>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Base64 { get; set; }

    public static IResponse<CreateMusicResponseViewModel, MusicDto> Convert(MusicDto dto)
    {
        if (dto is null) return null;
        
        return new CreateMusicResponseViewModel()
        {
            Id = dto.Id,
            Name = dto.Name,
            Base64 = dto.Base64
        };
    }
}