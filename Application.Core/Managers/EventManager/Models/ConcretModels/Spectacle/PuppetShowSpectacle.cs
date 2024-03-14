using Core.Services.Spectacle.Common;

namespace Application.Core.Managers.EventManager.Models.ConcretModels.Spectacle;

public class PuppetShowSpectacle : AbstractModels.Spectacle
{
    public static PuppetShowSpectacle From(SpectacleDto dto)
    {
        return new PuppetShowSpectacle()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Type = dto.Type
        };
    }
}