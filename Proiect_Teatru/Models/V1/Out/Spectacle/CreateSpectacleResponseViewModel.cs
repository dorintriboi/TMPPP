using Core.Services.Spectacle.Common;
using Domain.Entities.Spectacle.Enum;
using Proiect_Teatru.Models.Interfaces.Out;

namespace Proiect_Teatru.Models.V1.Out.Spectacle;

public class CreateSpectacleResponseViewModel: IResponse<CreateSpectacleResponseViewModel,SpectacleDto>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public SpectacleType Type { get; set; }

    public static IResponse<CreateSpectacleResponseViewModel, SpectacleDto> Convert(SpectacleDto dto)
    {
        if (dto is null) return null;
        
        return new CreateSpectacleResponseViewModel()
        {
            Id = dto.Id,
            Name = dto.Name,
            Type = dto.Type,
            Description = dto.Description
        };
    }
}