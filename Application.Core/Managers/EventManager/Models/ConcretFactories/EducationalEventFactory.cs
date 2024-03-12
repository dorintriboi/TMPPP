using Application.Core.Managers.EventManager.Models.AbstractFactories;
using Application.Core.Managers.EventManager.Models.AbstractModels;

namespace Application.Core.Managers.EventManager.Models.ConcretFactories;

public class EducationalEventFactory: IEventAbstractFactory
{
    public Spectacle CreateSpectacle()
    {
        throw new NotImplementedException();
    }

    public Team CreateTeam()
    {
        throw new NotImplementedException();
    }
}