using Domain.Core.Domain.Entities;

namespace Domain.Entities.Contract;

public class ContractEntity: FullAuditEntity
{
    public string Name { get; set; }
    public string Base64 { get; set; }
}