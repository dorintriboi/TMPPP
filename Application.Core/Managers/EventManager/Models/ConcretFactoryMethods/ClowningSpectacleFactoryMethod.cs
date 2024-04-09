using Application.Core.Managers.EventManager.Models.AbstractFactoryMethods;
using Application.Core.Managers.EventManager.Models.AbstractModels;
using Application.Core.Managers.EventManager.Models.ConcretModels.Spectacle;
using Core.Services.Spectacle.Queries.GetSpectacleById.DTOs;
using MediatR;

namespace Application.Core.Managers.EventManager.Models.ConcretFactoryMethods;

public class ClowningSpectacleFactoryMethod(IMediator mediator) : SpectacleAbstractFactoryMethod
{
    public override async Task<Spectacle> CreateSpectacle(string spectacleId)
    {
        var spectacle = await mediator.Send(new GetSpectacleByIdQuery() { SpectacleId = spectacleId });
        return ClowningSpectacle.From(spectacle);
    }
}