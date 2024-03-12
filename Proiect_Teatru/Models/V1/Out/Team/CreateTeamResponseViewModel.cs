using Core.Services.Team.Common;
using Proiect_Teatru.Models.Interfaces.Out;

namespace Proiect_Teatru.Models.V1.Out.Team;

public class CreateTeamResponseViewModel : IResponse<CreateTeamResponseViewModel,TeamDto>
{
    public string Id { get; set; }
    public string Name { get; set; }

    public static IResponse<CreateTeamResponseViewModel, TeamDto> Convert(TeamDto dto)
    {
        if (dto is null) return null;
        
        return new CreateTeamResponseViewModel()
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }
}