using Core.Services.Contract.Common;
using Proiect_Teatru.Models.Interfaces.Out;
using Proiect_Teatru.Models.V1.Out.Music;

namespace Proiect_Teatru.Models.V1.Out.Contract;

public class CreateContractResponseViewModel: IResponse<CreateContractResponseViewModel,ContractDto>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Base64 { get; set; }

    public static IResponse<CreateContractResponseViewModel, ContractDto> Convert(ContractDto dto)
    {
        if (dto is null) return null;
        
        return new CreateContractResponseViewModel()
        {
            Id = dto.Id,
            Name = dto.Name,
            Base64 = dto.Base64
        };
    }
}