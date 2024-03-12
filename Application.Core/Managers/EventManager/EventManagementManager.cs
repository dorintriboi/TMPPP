using Application.Core.Managers.EventManager.Interfaces;
using Application.Core.Managers.EventManager.Models.In;
using Application.Core.Managers.EventManager.Models.Out;
using MediatR;

namespace Application.Core.Managers.EventManager;

public class EventManagementManager:IEventManagementManager
{
    private readonly IMediator _mediator;
    public EventManagementManager(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public Task<EventResponseModel> CreateEvent(EventRequestModel model)
    {
        throw new NotImplementedException();
    }
}