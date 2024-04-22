using Domain.Entities.CompanyEvent;

namespace Core.Services.CompanyEvent.Common;

public class CompanyEventDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string TypeId { get; set; }
    
    public static CompanyEventDto From(CompanyEventEntity entity)
    {
        return new CompanyEventDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            TypeId = entity.TypeId
        };
    }
}