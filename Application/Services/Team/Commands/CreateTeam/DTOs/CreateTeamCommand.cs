using Core.Services.Team.Common;
using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Team.Commands.CreateTeam.DTOs;

public class CreateTeamCommand : BaseMediatorDtoValidation<CreateTeamCommand>, IRequest<TeamDto>
{
    public string Name { get; set; }
    protected override void Validation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name most be not null");
    }
}