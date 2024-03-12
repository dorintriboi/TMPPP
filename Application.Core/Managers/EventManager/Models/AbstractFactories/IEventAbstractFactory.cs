using Application.Core.Managers.EventManager.Models.AbstractModels;

namespace Application.Core.Managers.EventManager.Models.AbstractFactories;

public interface IEventAbstractFactory
{
    Spectacle CreateSpectacle();
    Team CreateTeam();
}