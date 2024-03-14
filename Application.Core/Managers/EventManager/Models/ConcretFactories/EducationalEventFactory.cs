using Application.Core.Managers.EventManager.Models.AbstractFactories;
using Application.Core.Managers.EventManager.Models.AbstractModels;

namespace Application.Core.Managers.EventManager.Models.ConcretFactories;

public class EducationalEventFactory: IEventAbstractFactory
{
    public Task<Spectacle> GetSpectacle(string spectacleId)
    {
        throw new NotImplementedException();
    }

    public Task<Team> GetTeam()
    {
        throw new NotImplementedException();
    }
}