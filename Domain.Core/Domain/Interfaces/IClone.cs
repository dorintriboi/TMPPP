using Domain.Core.Domain.Entities;

namespace Domain.Core.Domain.Interfaces;

public interface IClone<T> where T: Entity
{
    T Clone();
}