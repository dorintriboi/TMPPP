using Core.Services.Event.Commands.CloneEvent.DTOs;
using Proiect_Teatru.Models.Interfaces.In;

namespace Proiect_Teatru.Models.V1.In.Event;

public class CloneEventRequestViewModel: IRequest<CloneEventCommand>
{
    public string EventId { get; set; }
    public string InstitutionId { get; set; }
    public DateOnly Date { get; set; }
    public string Location { get; set; }
    public CloneEventCommand Convert()
    {
        return new CloneEventCommand()
        {
            EventId = EventId,
            InstitutionId = InstitutionId,
            Date = new DateTime(Date,new TimeOnly()),
            Location = Location
        };
    }
}