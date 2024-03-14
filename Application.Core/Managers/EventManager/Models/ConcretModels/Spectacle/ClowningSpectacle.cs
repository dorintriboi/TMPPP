using Core.Services.Spectacle.Common;

namespace Application.Core.Managers.EventManager.Models.ConcretModels.Spectacle;

public class ClowningSpectacle: AbstractModels.Spectacle
{
    public static ClowningSpectacle From(SpectacleDto dto)
    {
        return new ClowningSpectacle()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Type = dto.Type
        };
    }
}