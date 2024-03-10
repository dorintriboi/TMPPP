using Core.Services.Team.Common;

namespace Proiect_Teatru.Models.V1.Out.Team;

public class CreateTeamResponseViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }

    public static CreateTeamResponseViewModel Convert(TeamDto dto)
    {
        if (dto is null) return null;
        
        return new CreateTeamResponseViewModel()
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }
}