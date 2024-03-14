using Application.Core.Managers.EventManager.Models.Out;
using Proiect_Teatru.Models.Interfaces.Out;

namespace Proiect_Teatru.Models.V1.Out.Event;

public class CreateEventResponseViewModel : IResponse<CreateEventResponseViewModel,EventResponseModel>
{
    public static IResponse<CreateEventResponseViewModel, EventResponseModel> Convert(EventResponseModel entity)
    {
        throw new NotImplementedException();
    }
}