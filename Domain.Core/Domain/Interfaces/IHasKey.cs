namespace Domain.Core.Domain.Interfaces;

public interface IHasKey<out T>
{ 
    T Id { get; }
}