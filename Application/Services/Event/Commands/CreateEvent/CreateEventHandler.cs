using Core.Services.Event.Commands.CreateEvent.DTOs;
using Core.Services.Event.Common;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Event.Commands.CreateEvent;

public class CreateEventHandler(IApplicationUnitOfWork repository) : IRequestHandler<CreateEventCommand, EventDto>
{
    public Task<EventDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}