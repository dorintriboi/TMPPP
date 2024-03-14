using Core.Services.Spectacle.Common;
using Core.Services.Spectacle.Queries.GetSpectacleById.DTOs;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Spectacle.Queries.GetSpectacleById;

public class GetSpectacleByIdHandler(IApplicationUnitOfWork repository) : IRequestHandler<GetSpectacleByIdQuery, SpectacleDto>
{
    public async Task<SpectacleDto> Handle(GetSpectacleByIdQuery request, CancellationToken cancellationToken)
    {
        var spectacle = await repository.SpectacleRepository.GetByIdAsync(request.SpectacleId);

        return SpectacleDto.From(spectacle);
    }
}