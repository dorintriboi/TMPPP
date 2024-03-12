using Application.Core.Managers.EventManager.Models.AbstractFactories;

namespace Application.Core.Managers.EventManager.Models.AbstractModels;

public class Event
{
    private IEventAbstractFactory Factory { get; set; }

    public Event(IEventAbstractFactory factory)
    {
        Factory = factory;
    }
    
    public Spectacle Spectacle { get; set; }
    public Team Team { get; set; }
    public DateTime Date { get; set; }

    public Event CreateEvent(DateTime date)
    {
        Spectacle = Factory.CreateSpectacle();
        Team = Factory.CreateTeam();
        Date = date;
        
        return this;
    }
}