using Application.Core.Managers.EventManager.Models.In;
using Application.Core.Managers.EventManager.Models.Out;

namespace Application.Core.Managers.EventManager.Interfaces;

public interface IEventManagementManager
{
    Task<EventResponseModel> CreateEvent(EventRequestModel model);
}