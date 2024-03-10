using Core.Services.Team.Commands.CreateTeam.DTOs;

namespace Proiect_Teatru.Models.V1.In.Team;

public class CreateTeamRequestViewModel
{
    public string Name { get; set; }

    public CreateTeamCommand Convert()
    {
        return new CreateTeamCommand()
        {
            Name = Name
        };
    }
}