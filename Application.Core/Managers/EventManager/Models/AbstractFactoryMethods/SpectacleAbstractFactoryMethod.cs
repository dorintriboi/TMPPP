using Application.Core.Managers.EventManager.Models.AbstractModels;

namespace Application.Core.Managers.EventManager.Models.AbstractFactoryMethods;

public abstract class SpectacleAbstractFactoryMethod
{
    public abstract Task<Spectacle> CreateSpectacle(string spectacleId);
}