using Core.Services.Contract.Common;
using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Contract.Queries.GetContractById.DTOs;

public class GetContractByIdRequest: BaseMediatorDtoValidation<GetContractByIdRequest>, IRequest<ContractDto>
{
    public string ContractId { get; set; }
    protected override void Validation()
    {
        RuleFor(x => x.ContractId)
            .NotEmpty()
            .WithMessage("ContractId most be not null");
    }
}