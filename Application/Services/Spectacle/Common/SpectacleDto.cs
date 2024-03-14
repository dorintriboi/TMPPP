using Domain.Entities.Spectacle;
using Domain.Entities.Spectacle.Enum;

namespace Core.Services.Spectacle.Common;

public class SpectacleDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public SpectacleType Type { get; set; }
    
    public static SpectacleDto From(SpectacleEntity entity)
    {
        if (entity is null) return null;
        
        return new SpectacleDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Type = entity.Type
        };
    }
}