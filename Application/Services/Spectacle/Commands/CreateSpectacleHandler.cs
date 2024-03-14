using Core.Services.Spectacle.Commands.DTOs;
using Core.Services.Spectacle.Common;
using Domain.Entities.Spectacle;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Spectacle.Commands;

public class CreateSpectacleHandler(IApplicationUnitOfWork repository) : IRequestHandler<CreateSpectacleCommand, SpectacleDto>
{
    public async Task<SpectacleDto> Handle(CreateSpectacleCommand request, CancellationToken cancellationToken)
    {
        var spectacleEntity = SpectacleEntity.Create(request.Name, request.Description, request.Type);

        await repository.SpectacleRepository.InsertAsync(spectacleEntity);
        await repository.SaveAsync();
        
        return SpectacleDto.From(spectacleEntity);
    }
}