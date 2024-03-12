using Core.Services.Team.Commands.CreateTeam.DTOs;
using Proiect_Teatru.Models.Interfaces.In;

namespace Proiect_Teatru.Models.V1.In.Team;

public class CreateTeamRequestViewModel : IRequest<CreateTeamCommand>
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