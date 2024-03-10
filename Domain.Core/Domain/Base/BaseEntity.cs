using Domain.Core.Domain.Interfaces;

namespace Domain.Core.Domain.Base;

public class BaseEntity<T> : IHasKey<T>
{
    public T Id { get; set; }
}