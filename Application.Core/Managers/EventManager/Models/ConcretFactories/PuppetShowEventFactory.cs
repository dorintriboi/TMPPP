using Application.Core.Managers.EventManager.Models.AbstractFactories;
using Application.Core.Managers.EventManager.Models.AbstractModels;
using Application.Core.Managers.EventManager.Models.ConcretFactoryMethods;
using Domain.Entities.Spectacle.Enum;

namespace Application.Core.Managers.EventManager.Models.ConcretFactories;

public class PuppetShowEventFactory: IEventAbstractFactory
{
    public Spectacle CreateSpectacle()
    {
        var factory = new PuppetShowSpectacleFactory();
        return factory.CreateSpectacle(SpectacleType.PuppetShow);
    }

    public Team CreateTeam()
    {
        throw new NotImplementedException();
    }
}