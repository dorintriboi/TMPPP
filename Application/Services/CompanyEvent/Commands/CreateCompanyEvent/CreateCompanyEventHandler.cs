using Core.Services.CompanyEvent.Commands.CreateCompanyEvent.DTOs;
using Core.Services.CompanyEvent.Common;
using Core.Services.CompanyEvent.Common.ObserverPattern.Observers;
using Core.Services.CompanyEvent.Common.ObserverPattern.Subjects;
using Domain.Entities.CompanyEvent;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.CompanyEvent.Commands.CreateCompanyEvent;

public class CreateCompanyEventHandler
    (IApplicationUnitOfWork repository) : IRequestHandler<CreateCompanyEventCommand, CompanyEventDto>
{
    public async Task<CompanyEventDto> Handle(CreateCompanyEventCommand request, CancellationToken cancellationToken)
    {
        var eventType = await repository.CompanyEventTypeRepository.GetByIdAsync(request.TypeId);
        
        var eventDb = CompanyEventEntity.Create(request.Name, request.Description, eventType);

        await repository.CompanyEventRepository.InsertAsync(eventDb);

        await repository.SaveAsync();
        
        var employeesEvents = await repository.EmployeeCompanyEventTypeRepository.GetAllReadOnlyAsync();
        
        var employeesObservers = employeesEvents.Where(x => x.EventTypeId == eventType.Id)
            .Select(x => new EmployeeObserver() { Email = x.Employee.User.Email! });
        
        var employeeEvents = new EventSubject();
        
        foreach (var employee in employeesObservers)
        {
            employeeEvents.RegisterObserver(employee);
        }

        employeeEvents.NotifyObservers();

        return CompanyEventDto.From(eventDb);
    }
}