using Application.Core.Managers.EventManager.Interfaces;
using Application.Core.Managers.EventManager.Models.AbstractModels;
using Application.Core.Managers.EventManager.Models.ConcretFactories;
using Application.Core.Managers.EventManager.Models.In;
using Application.Core.Managers.EventManager.Models.Out;
using Core.Services.Event.Commands.CreateEvent.DTOs;
using MediatR;

namespace Application.Core.Managers.EventManager;

public class EventManagementManager: IEventManagementManager
{
    private readonly IMediator _mediator;
    public EventManagementManager(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<EventResponseModel> CreatePuppetShowEvent(EventRequestModel model)
    {
        var eventFactory = new PuppetShowEventFactory(_mediator);
        var abstractEvent = new Event(eventFactory);
        var concretEvent = await abstractEvent.CreateEvent(model.SpectacleId, model.Date);

        var result = await _mediator.Send(new CreateEventCommand()
        {
            InstitutionId = concretEvent.Spectacle.Id
        });

        return EventResponseModel.From(result);
    }

    public Task<EventResponseModel> CreateEducationalEvent(EventRequestModel model)
    {
        throw new NotImplementedException();
    }

    public Task<EventResponseModel> CreateLocalEvent(EventRequestModel model)
    {
        throw new NotImplementedException();
    }

    public Task<EventResponseModel> CreateClowningEvent(EventRequestModel model)
    {
        throw new NotImplementedException();
    }
}