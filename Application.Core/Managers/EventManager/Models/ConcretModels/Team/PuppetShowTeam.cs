using Core.Services.Team.Common;

namespace Application.Core.Managers.EventManager.Models.ConcretModels.Team;

public class PuppetShowTeam : AbstractModels.Team
{
    public static PuppetShowTeam From(TeamDto dto)
    {
        return new PuppetShowTeam()
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }
}