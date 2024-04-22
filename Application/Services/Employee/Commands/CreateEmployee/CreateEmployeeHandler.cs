using Core.Services.Employee.Commands.CreateEmployee.DTOs;
using Core.Services.Employee.Common;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Employee.Commands.CreateEmployee;

public class CreateEmployeeHandler(IApplicationUnitOfWork repository) : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
{
    public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}