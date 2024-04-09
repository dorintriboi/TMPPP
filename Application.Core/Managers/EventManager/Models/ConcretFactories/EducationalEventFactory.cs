using Application.Core.Managers.EventManager.Models.AbstractFactories;
using Application.Core.Managers.EventManager.Models.AbstractModels;
using Application.Core.Managers.EventManager.Models.ConcretFactoryMethods;
using Application.Core.Managers.EventManager.Models.ConcretModels.Team;
using Core.Services.Team.Queries.GetTeamBySpectacleType.DTOs;
using Domain.Entities.Spectacle.Enum;
using MediatR;

namespace Application.Core.Managers.EventManager.Models.ConcretFactories;

public class EducationalEventFactory(IMediator mediator): IEventAbstractFactory
{
    public async Task<Spectacle> GetSpectacle(string spectacleId)
    {
        var factory = new LocalSpectacleFactoryMethod(mediator);
        return await factory.CreateSpectacle(spectacleId);
    }

    public async Task<Team> GetTeam()
    {
        var team = await mediator.Send(new GetTeamBySpectacleTypeQuery() { Type = SpectacleType.Clowning });
        return PuppetShowTeam.From(team);
    }
}