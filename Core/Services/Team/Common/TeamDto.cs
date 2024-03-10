using Domain.Entities.Team;

namespace Core.Services.Team.Common;

public class TeamDto
{
    public string Id { get; set; }
    public string Name { get; set; }

    public static TeamDto From(TeamEntity entity)
    {
        if (entity is null) return null;
        
        return new TeamDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}