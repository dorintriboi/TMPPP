using Domain.Core.Domain.Entities;
using Domain.Entities.Event;
using Domain.Entities.SpectacleTeam;
using Domain.Entities.TeamMember;

namespace Domain.Entities.Team;

public class TeamEntity: FullAuditEntity
{
    public string Name { get; set; }
    public virtual ICollection<EventEntity> Events { get; set; }
    public virtual ICollection<TeamMemberEntity> Members { get; set; }
    public virtual ICollection<SpectacleTeamEntity> Spectacles { get; set; }

    public static TeamEntity Create(string Name)
    {
        return new TeamEntity()
        {
            Name = Name
        };
    }
}