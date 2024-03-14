using Application.Core.Managers.EventManager.Models.AbstractFactories;

namespace Application.Core.Managers.EventManager.Models.AbstractModels;

public class Event(IEventAbstractFactory factory)
{
    private IEventAbstractFactory Factory { get; set; } = factory;

    public Spectacle Spectacle { get; set; }
    public Team Team { get; set; }
    public DateTime Date { get; set; }

    public async Task<Event> CreateEvent(string spectacleId, DateTime date)
    {
        Spectacle = await Factory.GetSpectacle(spectacleId);
        Team = await Factory.GetTeam();
        Date = date;
        
        return this;
    }
}