using Core.Services.Contract.Common;
using Core.Validations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Services.Contract.Commands.CreateContract.DTOs;

public class CreateContractCommand: BaseMediatorDtoValidation<CreateContractCommand>, IRequest<ContractDto>
{
    public string Name { get; set; }
    public IFormFile Contract { get; set; }
    
    protected override void Validation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name most be not null");
        
        RuleFor(x => x.Contract)
            .NotEmpty()
            .WithMessage("TeamId most be not null");
    }
}