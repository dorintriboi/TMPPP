using Application.Core.Managers.EventManager.Models.In;
using Application.Core.Managers.EventManager.Models.Out;

namespace Application.Core.Managers.EventManager.Interfaces;

public interface IEventManagementManager
{
    Task<EventResponseModel> CreatePuppetShowEvent(EventRequestModel model);
    Task<EventResponseModel> CreateEducationalEvent(EventRequestModel model);
    Task<EventResponseModel> CreateLocalEvent(EventRequestModel model);
    Task<EventResponseModel> CreateClowningEvent(EventRequestModel model);
}