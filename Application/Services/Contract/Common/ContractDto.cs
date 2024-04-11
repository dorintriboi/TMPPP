using Core.Services.Contract.Common.AdapterPattern.Interfaces;
using Domain.Entities.Contract;

namespace Core.Services.Contract.Common;

public class ContractDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Base64 { get; set; }

    public static async Task<ContractDto> From(ContractEntity entity, IWordConverter converter)
    {
        return new ContractDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Base64 = await converter.ConvertToWord(await new StreamContent(new MemoryStream(Convert.FromBase64String(entity.Base64))).ReadAsStreamAsync())
        };
    }
}