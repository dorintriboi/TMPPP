using Application.Core.Managers.EventManager.Models.AbstractFactoryMethods;
using Application.Core.Managers.EventManager.Models.AbstractModels;
using Application.Core.Managers.EventManager.Models.ConcretModels;
using Core.Services.Spectacle.Queries.GetSpectacleById.DTOs;
using MediatR;

namespace Application.Core.Managers.EventManager.Models.ConcretFactoryMethods;

public class PuppetShowSpectacleFactory(IMediator mediator) : SpectacleAbstractFactory
{
    public override async Task<Spectacle> CreateSpectacle(string spectacleId)
    {
        var spectacle = await mediator.Send(new GetSpectacleByIdQuery() { SpectacleId = spectacleId });
        return PuppetShowSpectacle.From(spectacle);
    }
}