using Application.Core.Managers.EventManager.Models.AbstractModels;
using Domain.Entities.Spectacle.Enum;

namespace Application.Core.Managers.EventManager.Models.AbstractFactoryMethods;

public abstract class SpectacleAbstractFactory
{
    public abstract Spectacle CreateSpectacle(SpectacleType type);
}