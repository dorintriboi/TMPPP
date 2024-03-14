using Application.Core.Managers.EventManager.Models.In;
using Proiect_Teatru.Models.Interfaces.In;

namespace Proiect_Teatru.Models.V1.In.Event;

public class CreateEventRequestViewModel : IRequest<EventRequestModel>
{
    public EventRequestModel Convert()
    {
        throw new NotImplementedException();
    }
}