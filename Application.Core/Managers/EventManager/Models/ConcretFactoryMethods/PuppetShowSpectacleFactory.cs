using Application.Core.Managers.EventManager.Models.AbstractFactoryMethods;
using Application.Core.Managers.EventManager.Models.AbstractModels;
using Domain.Entities.Spectacle.Enum;

namespace Application.Core.Managers.EventManager.Models.ConcretFactoryMethods;

public class PuppetShowSpectacleFactory : SpectacleAbstractFactory
{
    public override Spectacle CreateSpectacle(SpectacleType type)
    {
        throw new NotImplementedException();
    }
}