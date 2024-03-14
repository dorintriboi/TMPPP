using Application.Core.Managers.EventManager.Models.AbstractFactories;
using Domain.Entities.Event.Enum;

namespace Application.Core.Managers.EventManager.Models.AbstractModels;

public class Event(IEventAbstractFactory factory)
{
    private IEventAbstractFactory Factory { get; set; } = factory;

    public Spectacle Spectacle { get; set; }
    public Team Team { get; set; }
    
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public EventStatusType Status { get; set; }

    public async Task<Event> CreateEvent(string spectacleId, string location, DateTime date)
    {
        Spectacle = await Factory.GetSpectacle(spectacleId);
        Team = await Factory.GetTeam();
        Date = date;
        Status = EventStatusType.Created;
        Location = location;
        
        return this;
    }
}