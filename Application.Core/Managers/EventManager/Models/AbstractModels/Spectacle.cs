using Domain.Entities.Spectacle.Enum;

namespace Application.Core.Managers.EventManager.Models.AbstractModels;

public abstract class Spectacle
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public SpectacleType Type { get; set; }
}