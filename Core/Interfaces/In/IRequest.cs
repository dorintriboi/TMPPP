namespace Core.Interfaces.In;

public interface IRequest<T>
{ 
    T Convert();
}