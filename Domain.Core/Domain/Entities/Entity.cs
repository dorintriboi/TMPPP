using Domain.Core.Domain.Base;

namespace Domain.Core.Domain.Entities;

public abstract class Entity : BaseEntity<string>
{
    protected Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
}