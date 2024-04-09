using Application.Core.Managers.EventManager.Models.AbstractModels;

namespace Application.Core.Managers.EventManager.Models.AbstractFactories;

public interface IEventAbstractFactory
{
    Task<Spectacle> GetSpectacle(string spectacleId);
    Task<Team> GetTeam();
}