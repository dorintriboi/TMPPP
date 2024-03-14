using Core.Services.Event.Commands.CreateEvent.DTOs;
using Core.Services.Event.Common;
using Domain.Entities.Event;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Event.Commands.CreateEvent;

public class CreateEventHandler(IApplicationUnitOfWork repository) : IRequestHandler<CreateEventCommand, EventDto>
{
    public async Task<EventDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var institution = await repository.InstitutionRepository.GetByIdAsync(request.InstitutionId);
        var team = await repository.TeamRepository.GetByIdAsync(request.TeamId);
        var spectacle = await repository.SpectacleRepository.GetByIdAsync(request.SpectacleId);
        
        var eventEntity = EventEntity.Create(institution, team, spectacle, request.Date.LocalDateTime,
            request.Location, request.Status);
        
        await repository.EventRepository.InsertAsync(eventEntity);
        await repository.SaveAsync();
        
        return EventDto.From(eventEntity);
    }
}