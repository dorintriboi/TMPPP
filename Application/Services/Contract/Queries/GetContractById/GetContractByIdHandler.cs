using Core.Services.Contract.Common;
using Core.Services.Contract.Common.AdapterPattern;
using Core.Services.Contract.Queries.GetContractById.DTOs;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Contract.Queries.GetContractById;

public class GetContractByIdHandler(IApplicationUnitOfWork repository) : IRequestHandler<GetContractByIdRequest, ContractDto>
{
    public async Task<ContractDto> Handle(GetContractByIdRequest request, CancellationToken cancellationToken)
    {
        var contract = await repository.ContractRepository.GetByIdAsync(request.ContractId);

        return await ContractDto.From(contract, new PdfAdapter(new PdfConverter()));
    }
}