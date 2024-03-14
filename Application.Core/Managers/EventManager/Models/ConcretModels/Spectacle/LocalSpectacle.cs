using Core.Services.Spectacle.Common;

namespace Application.Core.Managers.EventManager.Models.ConcretModels.Spectacle;

public class LocalSpectacle : AbstractModels.Spectacle
{
    public static LocalSpectacle From(SpectacleDto dto)
    {
        return new LocalSpectacle()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Type = dto.Type
        };
    }
}