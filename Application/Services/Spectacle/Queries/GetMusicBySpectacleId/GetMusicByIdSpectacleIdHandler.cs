using Core.Services.Spectacle.Queries.GetMusicBySpectacleId.DTOs;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Spectacle.Queries.GetMusicBySpectacleId;

public class GetMusicByIdSpectacleIdHandler
    (IApplicationUnitOfWork repository) : IRequestHandler<GetMusicBySpectacleIdQuery, IEnumerable<MusicDto>>
{
    public async Task<IEnumerable<MusicDto>> Handle(GetMusicBySpectacleIdQuery request,
        CancellationToken cancellationToken)
    {
        var spectacle = await repository.SpectacleRepository.GetByIdAsync(request.SpectacleId);
        return null;
    }
}