using Application.Core.Managers.EventManager.Models.AbstractModels;

namespace Application.Core.Managers.EventManager.Models.AbstractFactoryMethods;

public abstract class SpectacleAbstractFactory
{
    public abstract Task<Spectacle> CreateSpectacle(string SpectacleId);
}