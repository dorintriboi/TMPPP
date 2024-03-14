using Application.Core.Managers.EventManager.Models.AbstractFactories;
using Application.Core.Managers.EventManager.Models.AbstractModels;
using Application.Core.Managers.EventManager.Models.ConcretFactoryMethods;
using MediatR;

namespace Application.Core.Managers.EventManager.Models.ConcretFactories;

public class PuppetShowEventFactory(IMediator mediator): IEventAbstractFactory
{
    public async Task<Spectacle> GetSpectacle(string spectacleId)
    {
        var factory = new PuppetShowSpectacleFactory(mediator);
        return await factory.CreateSpectacle(spectacleId);
    }

    public Task<Team> GetTeam()
    {
        throw new NotImplementedException();
    }
}