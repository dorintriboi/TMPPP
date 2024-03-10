using Core.Services.Team.Commands.CreateTeam.DTOs;
using Core.Services.Team.Common;
using Domain.Entities.Team;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Team.Commands.CreateTeam;

public class CreateTeamHandler(IApplicationUnitOfWork repository) : IRequestHandler<CreateTeamCommand, TeamDto>
{
    public async Task<TeamDto> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = TeamEntity.Create(request.Name);
        
        await repository.TeamRepository.InsertAsync(team);
        await repository.SaveAsync();
        
        return TeamDto.From(team);
    }
}