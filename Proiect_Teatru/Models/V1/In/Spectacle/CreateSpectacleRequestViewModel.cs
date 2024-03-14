using Core.Services.Spectacle.Commands.DTOs;
using Domain.Entities.Spectacle.Enum;
using MediatR;

namespace Proiect_Teatru.Models.V1.In.Spectacle;

public class CreateSpectacleRequestViewModel: IRequest<CreateSpectacleCommand>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public SpectacleType Type { get; set; }

    public CreateSpectacleCommand Convert()
    {
        return new CreateSpectacleCommand()
        {
            Name = Name,
            Description = Description,
            Type = Type
        };
    }
}