using Application.Core.Managers.EventManager.Models.AbstractModels;
using Core.Services.Spectacle.Common;

namespace Application.Core.Managers.EventManager.Models.ConcretModels;

public class PuppetShowSpectacle : Spectacle
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