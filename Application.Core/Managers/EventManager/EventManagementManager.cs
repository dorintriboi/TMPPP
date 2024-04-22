using Application.Core.Managers.EventManager.Interfaces;
using Application.Core.Managers.EventManager.Models.AbstractModels;
using Application.Core.Managers.EventManager.Models.ConcretFactories;
using Application.Core.Managers.EventManager.Models.In;
using Application.Core.Managers.EventManager.Models.Out;
using Core.Services.Event.Commands.CreateEvent.DTOs;
using MediatR;

namespace Application.Core.Managers.EventManager;

public class EventManagementManager(IMediator mediator) : IEventManagementManager
{
    public async Task<EventResponseModel> CreatePuppetShowEvent(EventRequestModel model)
    {
        var eventFactory = new PuppetShowEventFactory(mediator);
        var abstractEvent = new Event(eventFactory);
        var concretEvent = await abstractEvent.CreateEvent(model.SpectacleId, model.Location, model.Date);

        var result = await mediator.Send(new CreateEventCommand()
        {
            InstitutionId = model.InstitutionId,
            TeamId = concretEvent.Team.Id, 
            SpectacleId = concretEvent.Spectacle.Id, 
            Date = concretEvent.Date, 
            Location = concretEvent.Location,
            Status = concretEvent.Status
        });

        return EventResponseModel.From(result);
    }

    public async Task<EventResponseModel> CreateEducationalEvent(EventRequestModel model)
    {
        var eventFactory = new EducationalEventFactory(mediator);
        var abstractEvent = new Event(eventFactory);
        var concretEvent = await abstractEvent.CreateEvent(model.SpectacleId, model.Location, model.Date);

        var result = await mediator.Send(new CreateEventCommand()
        {
            InstitutionId = model.InstitutionId,
            TeamId = concretEvent.Team.Id, 
            SpectacleId = concretEvent.Spectacle.Id, 
            Date = concretEvent.Date, 
            Location = concretEvent.Location,
            Status = concretEvent.Status
        });

        return EventResponseModel.From(result);
    }

    public async Task<EventResponseModel> CreateLocalEvent(EventRequestModel model)
    {
        var eventFactory = new LocalEventFactory(mediator);
        var abstractEvent = new Event(eventFactory);
        var concretEvent = await abstractEvent.CreateEvent(model.SpectacleId, model.Location, model.Date);

        var result = await mediator.Send(new CreateEventCommand()
        {
            InstitutionId = model.InstitutionId,
            TeamId = concretEvent.Team.Id, 
            SpectacleId = concretEvent.Spectacle.Id, 
            Date = concretEvent.Date, 
            Location = concretEvent.Location,
            Status = concretEvent.Status
        });

        return EventResponseModel.From(result);
    }

    public async Task<EventResponseModel> CreateClowningEvent(EventRequestModel model)
    {
        var eventFactory = new ClowningEventFactory(mediator);
        var abstractEvent = new Event(eventFactory);
        var concretEvent = await abstractEvent.CreateEvent(model.SpectacleId, model.Location, model.Date);

        var result = await mediator.Send(new CreateEventCommand()
        {
            InstitutionId = model.InstitutionId,
            TeamId = concretEvent.Team.Id, 
            SpectacleId = concretEvent.Spectacle.Id, 
            Date = concretEvent.Date, 
            Location = concretEvent.Location,
            Status = concretEvent.Status
        });

        return EventResponseModel.From(result);
    }
}