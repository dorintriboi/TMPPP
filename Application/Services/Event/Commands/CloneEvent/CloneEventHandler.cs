using Core.Services.Event.Commands.CloneEvent.DTOs;
using Core.Services.Event.Common;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Event.Commands.CloneEvent;

public class CloneEventHandler(IApplicationUnitOfWork repository) : IRequestHandler<CloneEventCommand, EventDto>
{
    public async Task<EventDto> Handle(CloneEventCommand request, CancellationToken cancellationToken)
    {
        var institution = await repository.InstitutionRepository.GetByIdAsync(request.InstitutionId);
        var eventEntity = await repository.EventRepository.GetByIdAsync(request.EventId);
        var newEvent = eventEntity.Clone();

        newEvent.Institution = institution;
        newEvent.Date = request.Date;
        newEvent.Location = request.Location;
        
        await repository.EventRepository.InsertAsync(newEvent);
        await repository.SaveAsync();
        
        return EventDto.From(newEvent);
    }
}