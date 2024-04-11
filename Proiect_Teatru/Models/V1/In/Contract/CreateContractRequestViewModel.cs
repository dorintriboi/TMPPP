using Core.Services.Contract.Commands.CreateContract.DTOs;
using MediatR;

namespace Proiect_Teatru.Models.V1.In.Contract;

public class CreateContractRequestViewModel: IRequest<CreateContractCommand>
{
    public string Name { get; set; }
    public IFormFile Contract { get; set; }

    public CreateContractCommand Convert()
    {
        return new CreateContractCommand()
        {
            Name = Name,
            Contract = Contract
        };
    }
}