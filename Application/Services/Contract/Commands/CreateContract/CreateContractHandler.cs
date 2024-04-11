using Core.Services.Contract.Commands.CreateContract.DTOs;
using Core.Services.Contract.Common;
using Core.Services.Contract.Common.AdapterPattern;
using Domain.Entities.Contract;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Contract.Commands.CreateContract;

public class CreateContractHandler(IApplicationUnitOfWork repository) : IRequestHandler<CreateContractCommand, ContractDto>
{
    public async Task<ContractDto> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        var contract = new ContractEntity();
        contract.Name = request.Name;
        await using var memoryStream = new MemoryStream();

        await request.Contract.CopyToAsync(memoryStream, cancellationToken);

        byte[] b = memoryStream.ToArray();

        contract.Base64 = Convert.ToBase64String(b);

        await repository.ContractRepository.InsertAsync(contract);
        await repository.SaveAsync();
        
        return await ContractDto.From(contract, new PdfAdapter(new PdfConverter()));
    }
}